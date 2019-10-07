using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INOM.Entities
{
    public class InstructionFundsCancelOrder : Instruction
    {
        public static void Save(InstructionFundsCancelOrder instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsCancelOrders.Add(instructionFund);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Order ID affected. 
        /// </summary>
        public int OrderID { get; set; }

        public static List<InstructionFundsCancelOrder> GetAll()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstructionFundsCancelOrders select data).ToList();
            }
        }

        public static void Update(InstructionFundsCancelOrder instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsCancelOrders.Attach(instructionFund);
                db.Entry(instructionFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static bool Validate(InstructionFundsCancelOrderInput item, OrderFund orderFund, out string sCod, out string sMessage)
        {
            sMessage = "";
            sCod = "";
            bool calendar = true;
            if (item.Status == "C")
            { 
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0005.ToString());
                sCod = EnumErrorCode.OMS0005.ToString();
                return false;
            }
            else
            {
                if (item.OrderID == 0)//|| item.OrderID == null)
                {
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0006.ToString());
                    sCod = EnumErrorCode.OMS0006.ToString();
                    return false;
                }
            }
               
            if (orderFund == null)
            {
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0033.ToString());
                sCod = EnumErrorCode.OMS0033.ToString();
                return false;
            }
            else
            {
                if (orderFund.Status != "P" && orderFund.Status != "C")
                {
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0007.ToString());
                    sCod = EnumErrorCode.OMS0007.ToString();
                    return false;
                }
            }
     
            InstructionFundsCancelOrder instructionFund = Retrieve.GetInstructionCancelFromOrderID(item.OrderID);
            if (instructionFund != null)
            { 
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0008.ToString());
                sCod = EnumErrorCode.OMS0008.ToString();
                return false;
            }

            // Para migración de Tenencia no validamos la fecha
            if (orderFund.OnlyMigration == 0 && sMessage.Length == 0)
            {
                Calendar calendarVerifyDate = new Calendar();
                calendarVerifyDate.FundID = Convert.ToInt32(orderFund.FundID);
                calendarVerifyDate.Date = item.InstructionExecutionDateTime;
                calendar = Calendar.Validate(calendarVerifyDate,out sCod, out sMessage);
            }

            return sMessage.Length == 0;
        }

        public static bool Validate(InstructionFundsCancelOrderNumberInput item, OrderFund orderFund, out string sCod, out string sMessage)
        {
            sMessage = "";
            sCod = "";
            bool calendar = true;
            if (item.Status == "C")
            {
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0005.ToString());
                sCod = EnumErrorCode.OMS0005.ToString();
                return false;
            }
            else
            {
                if (item.OrderNumber == 0)
                {
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0046.ToString());
                    sCod = EnumErrorCode.OMS0046.ToString();
                    return false;
                }
            }

            if (orderFund == null)
            {
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0033.ToString());
                sCod = EnumErrorCode.OMS0033.ToString();
                return false;
            }
            else
            {
                if (orderFund.Status != "P" && orderFund.Status != "C")
                {
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0007.ToString());
                    sCod = EnumErrorCode.OMS0007.ToString();
                    return false;
                }
            }

            InstructionFundsCancelOrder instructionFund = Retrieve.GetInstructionCancelFromOrderID(orderFund.OrderID);
            if (instructionFund != null)
            {
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0008.ToString());
                sCod = EnumErrorCode.OMS0008.ToString();
                return false;
            }

            // Para migración de Tenencia no validamos la fecha
            if (orderFund.OnlyMigration == 0 && sMessage.Length == 0)
            {
                Calendar calendarVerifyDate = new Calendar();
                calendarVerifyDate.FundID = Convert.ToInt32(orderFund.FundID);
                calendarVerifyDate.Date = item.InstructionExecutionDateTime;
                calendar = Calendar.Validate(calendarVerifyDate, out sCod, out sMessage);
            }

            return sMessage.Length == 0;
        }
    }
}
