using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class InstructionFundsTransferFund : Instruction
    {
        public static void Save(InstructionFundsTransferFund instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsTransferFunds.Add(instructionFund);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Order ID affected. 
        /// </summary>
        [StringLength(30)]
        public string OriginCustodyAccountNo { get; set; }
        public int OriginFundID { get; set; }
        public decimal OriginAmount { get; set; }
        public decimal OriginShares { get; set; }
        public string OriginRescueType { get; set; }
        public string OriginCurrency { get; set; }
        public string TargetCustodyAccountNo { get; set; }
        public int TargetFundID { get; set; }

        public static List<InstructionFundsTransferFund> GetAll()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstructionFundsTransferFunds select data).ToList();
            }
        }
        public static void Update(InstructionFundsTransferFund instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsTransferFunds.Attach(instructionFund);
                db.Entry(instructionFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static bool Validate(InstructionFundsTransferFund item, out string sCod, out string sMessage)
        {
            sMessage = "";
            sCod = "";
            bool calendar = true;

            Calendar calendarVerifyDate = new Calendar();
            calendarVerifyDate.FundID = Convert.ToInt32(item.TargetFundID);
            calendarVerifyDate.Date = item.InstructionExecutionDateTime;
            calendar = Calendar.Validate(calendarVerifyDate,out sCod, out sMessage);
            return sMessage.Length == 0;
        }

        public int GetTypeTransfer()
        {

            if (this.OriginCustodyAccountNo == this.TargetCustodyAccountNo && this.OriginFundID != this.TargetFundID)
            {
                return 2;
            }
            if (this.OriginCustodyAccountNo != this.TargetCustodyAccountNo && this.OriginFundID == this.TargetFundID)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
