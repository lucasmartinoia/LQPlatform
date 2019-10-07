using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class Bonus
    {
        /// <summary>
        /// Bonus ID
        /// </summary>
        [Key]
        public int BonusID { get; set; }

        /// <summary>
        /// Related Order ID (ID de la orden sobre la cual se aplica la bonificacion).
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Order related (Orden sobre la cual se aplica la bonificacion).
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Bonus code for bonus identification (Codigo de la bonificación a aplicar).
        /// </summary>
        [StringLength(10)]
        public string Code { get; set; }

        /// <summary>
        /// Applicable amount for this bonus (Importe sobre el cual se aplica la bonificación).
        /// </summary>
        public Decimal? Amount { get; set; }

        /// <summary>
        /// Applicable shares for this bonus (Cantidad de nominales sobre los que aplica la bonificacion).
        /// </summary>
        public Decimal? Shares { get; set; }

        /// <summary>
        /// Bonus Fee (Importe Bonificado).
        /// </summary>
        public Decimal? BonusFee { get; set; }

        /// <summary>
        /// Bonus Rate (Porcentaje de bonificación a aplicar sobre el Amount ó sobre Shares).
        /// </summary>
        public float? BonusRate { get; set; }

        /// <summary>
        /// Date and time of last update (Fecha y hora de la ultima actualización del registro).
        /// </summary>
        public DateTime LastUpdate { get; set; }

        public static void Save(Bonus bonus)
        {
            using (var db = new DBContext())
            {
                db.Bonuses.Add(bonus);
                db.SaveChanges();
            }
        }

        public static void Update(Bonus bonus)
        {
            using (var db = new DBContext())
            {
                db.Bonuses.Attach(bonus);
                db.Entry(bonus).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
