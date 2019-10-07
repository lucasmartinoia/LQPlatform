using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class InstructionFundsPromoteClass : Instruction
    {
        public static void Save(InstructionFundsPromoteClass instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsPromoteClasses.Add(instructionFund);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Client custody account.
        /// </summary>
        [StringLength(30)]
        public string CustodyAccountNo { get; set; }

        /// <summary>
        /// Target Fund ID is the Fund Class where all client holdings will be migrated for.
        /// </summary>
        public int TargetFundID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
  
        public static void Update(InstructionFundsPromoteClass oInstruction)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsPromoteClasses.Attach(oInstruction);
                db.Entry(oInstruction).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static int Search(OrderFund item)
        {
            int instructionID = Retrieve.GetInstructionIDFromToday(item);
            return instructionID;
        }
        public static bool Validate(InstructionFundsPromoteClass item, out string sCod,out string sMessage)
        {
            sMessage = "";
            sCod = "";
            bool calendar = true;
            if (item.Status == "C")
            { 
                sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0005.ToString());
                sCod = EnumErrorCode.OMS0005.ToString();
            }
            else
                if (item.TargetFundID == 0)
                { 
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0006.ToString());
                    sCod = EnumErrorCode.OMS0006.ToString(); ;
                }
            if (sMessage.Length == 0)
            {
                Calendar calendarVerifyDate = new Calendar();
                calendarVerifyDate.FundID = item.TargetFundID;
                calendarVerifyDate.Date = item.InstructionExecutionDateTime;
                calendar = Calendar.Validate(calendarVerifyDate,out sCod, out sMessage);
            }
            return sMessage.Length == 0;
        }

        public int GetTypeTransfer()
        {
            return 1;
        }
    }
}
