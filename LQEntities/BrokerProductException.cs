using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INOM.Entities
{
    public class BrokerProductException       
    {
        /// <summary>
        /// Broker identifier.
        /// </summary>
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10)]
        public string BrokerID { get; set; }
        /// <summary>
        /// Product ID.
        /// </summary>
        [Key]
        public string ProductID { get; set; }
        /// <summary>
        /// Indicate type of product in Calypso (i.e. "Fondos", "Bonds", "Cautions", etc.).
        /// </summary>
        [StringLength(50)]
        public string ProductTypeID { get; set; }
        /// <summary>
        /// Record creation date and time.
        /// </summary>
        public DateTime SetupDateTime { get; set; }
        /// <summary>
        /// Setup User.
        /// </summary>
        public string SetupUser { get; set; }
        /// <summary>
        /// Modification date and time.
        /// </summary>
        public DateTime ModifiedDateTime { get; set; }
        /// <summary>
        /// Modification user.
        /// </summary>
        public string ModifiedUser { get; set; }
    }
}
