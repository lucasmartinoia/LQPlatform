using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class CalypsoResponse
    {
        [Key]
        public int CalypsoResponseID { get; set; }
        public int? MarketTradeID { get; set; }
        public int? InstructionID { get; set; }
        public int OrderID { get; set; }
        [StringLength(1)]
        public string Status{ get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual Instruction Instruction { get; set; }
        public virtual Order Order{ get; set; }
        public virtual FundsTrade FundsTrade { get; set; }

        public static void Save(CalypsoResponse calypsoResponse)
        {
            using (var db = new DBContext())
            {
                db.CalypsoResponses.Add(calypsoResponse);
                db.SaveChanges();
            }
        }
    }
}
