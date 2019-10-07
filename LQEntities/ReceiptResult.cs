using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class ReceiptResult
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        public int ReceiptID { get; set; }
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; }
        public string StorageID { get; set; }
        public string ReceiptType { get; set; }
    }
}
