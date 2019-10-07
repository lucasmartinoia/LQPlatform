using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INOM.Entities
{
    public class Broker
    {
        /// <summary>
        /// Broker identifier.
        /// </summary>
        //[Key]
        //public int ID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(450)]
        public string BrokerID { get; set; }
        /// <summary>
        /// Broker name (i.e. BGBA, Galicia Valores).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Broker description.
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// Broker name (i.e. BGBA, Galicia Valores).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TradeBook { get; set; }
        /// <summary>
        /// Indicates if the broker belongs to "Grupo Financiero Galicia" or not. It's useful for Argentina Central Bank reports and normatives.
        /// </summary>
        public bool Internal { get; set; }
        /// <summary>
        /// Handle broker availability.
        /// </summary>
        public bool Active { get; set; }

        public bool IsAcdi { get; set; }

        public string ClientID { get; set; }
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
        /// <summary>
        /// Product types availables for the broker.
        /// </summary>
        public virtual List<BrokerProductType> ProductTypes { get; set; }
        /// <summary>
        /// Products explicitly not allowed to trade.
        /// </summary>
        public virtual List<BrokerProductException> ProductExceptions { get; set; }
    }
}
