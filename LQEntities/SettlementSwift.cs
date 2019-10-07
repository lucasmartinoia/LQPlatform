namespace INOM.Entities
{
    public class SettlementSwift : Settlement
    {
        public static void Save(SettlementSwift settlementSwift)
        {
            using (var db = new DBContext())
            {
                db.SettlementSwifts.Add(settlementSwift);
                db.SaveChanges();
            }
        }
        public string SwiftBIC { get; set; }
    }
}
