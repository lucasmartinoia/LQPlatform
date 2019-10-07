using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace INOM.Entities
{
    public class InstrumentMarketHist 
    {
        [Key]
        public int InstrumentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CVDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeCV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeEuroclear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeIsin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeDtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeMae { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeRic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeTicker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SetupDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string SetupUser { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string VerifiedUser { get; set; }

        public static List<InstrumentMarketHist> GetList()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentMarketsHist select data).ToList();
            }
        }
    }
}
