using Microsoft.EntityFrameworkCore;

namespace INOM.Entities
{
    public class InstructionFundsPermanent : Instruction
    {
        public int SchedulerID { get; set; }
        public static void Save(InstructionFundsPermanent instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsPermanents.Add(instructionFund);
                db.SaveChanges();
            }
        }

        public static void Update(InstructionFundsPermanent instructionFund)
        {
            using (var db = new DBContext())
            { 
                db.InstructionFundsPermanents.Attach(instructionFund);
                db.Entry(instructionFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
