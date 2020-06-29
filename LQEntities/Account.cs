using System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class Account
    {
        public static Account CurrentAccount = null;

        [Key]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string CustodyAccount { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public enumAccountType AccountType { get; set; }
        public decimal CashMarginAmount { get; set; }

        public enum enumAccountType : int
        {
            Demo,
            Production,
        }

        public static List<Account> GetList()
        {
            List<Account> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.Accounts.ToList();
            }

            return colReturn;
        }
    }
}
