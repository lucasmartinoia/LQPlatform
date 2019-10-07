using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INOM.Entities
{
    public class RejectParameter
    {
        [Key]
        public int RejectParametersID { get; set; }
        public int IdObject { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string RejectReason { get; set; }
        public DateTime? SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }

        public static RejectParameter Save(RejectParameter reject)
        {
            using (var db = new DBContext())
            {
                db.RejectParameters.Add(reject);
                db.SaveChanges();

                return reject;
            }
        }
    }
}
