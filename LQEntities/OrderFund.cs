using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class OrderFund : Order, ICloneable
    {

        /// <summary>
        /// Indica el tipo de transferencia de la operación: 0 = No es transferencia, 1 = Promoción de Clase, 2= Transferencia entre Fondos en la misma cuenta comitente.
        /// </summary>
        public int? TypeTransfer { get; set; }

        /// <summary>
        /// Product code.
        /// </summary>
        public string FundID { get; set; }
        
        /// <summary>
        /// Rescue type: P = Partial or T = Total.
        /// </summary>
        [StringLength(1)]
        public string RescueType { get; set; }
        
        /// <summary>
        /// Order Input Mode : I = Importe, C = Cuotapartes
        /// </summary>
        public string OrderInputMode { get; set; }

        /// <summary>
        /// True if client has just sign the fund contract
        /// </summary>
        public bool? NewContractSignature { get; set; }

        public static void Save(OrderFund orderFund)
        {
            using (var db = new DBContext())
            {
                db.OrderFunds.Add(orderFund);
                db.SaveChanges();
            }
        }

        public static void Update(OrderFund orderFund)
        {
            using (var db = new DBContext())
            {
                db.OrderFunds.Attach(orderFund);
                db.Entry(orderFund).Property(x => x.Status).IsModified = true;
                db.Entry(orderFund).Property(x => x.LastUpdate).IsModified = true;
                db.SaveChanges();
            }
        }
        public static void UpdateAll(OrderFund orderFund)
        {
            using (var db = new DBContext())
            {
                db.OrderFunds.Attach(orderFund);
                db.Entry(orderFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static List<OrderFund> GetAll()
        {
            using (var db = new DBContext())
            {
                return (from data in db.OrderFunds select data).ToList();
            }
        }
        public static void UpdateMasive(int instructionID)
        {
            using (var db = new DBContext())
            {
                var friends = db.OrderFunds.Where(f => instructionID==f.InstructionID).ToList();
                friends.ForEach(a =>
                {
                    a.Status = "E";
                    a.LastUpdate = DateTime.Now;
                }
                    );
                db.SaveChanges();
            }
        }
        public static bool Validate(OrderFund item, out string sCod,out string sMessage)
        {
            // brokerid, canal y external reference, siempre que external reference sea > 0, sino no verificamos.Mensaje de error "Orden <numero> existente en OMS".
            sMessage = "";
            sCod = "";
            bool calendar = true;
            if (item.ExternalReference > 0)
            {
                int orderID = Retrieve.GetOrderIDByExternalReference(item);
                if (orderID > 0)
                {
                    //sMessage = String.Format(LogError.ReadErrorDescription(EnumErrorCode.OMS0022.ToString()), orderID);
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0022.ToString());
                    sCod = EnumErrorCode.OMS0022.ToString();
                }
            }
            if (sMessage.Length == 0 && !(item.Scheduled==true && item.BrokerID!="BGBA"))
            {
                Calendar calendarVerifyDate = new Calendar();
                calendarVerifyDate.FundID = Convert.ToInt32(item.FundID);
                calendarVerifyDate.Date = (DateTime)item.ExecutionDate;
                calendar = Calendar.Validate(calendarVerifyDate, out sCod, out sMessage);
            }
            return sMessage.Length == 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public enum TypeTransferEnum
        {
            Default = 0,
            FundsPromoteClass = 1,
            SubscriptionByShares = 2,
            Transfer = 3
        };
    }
}
