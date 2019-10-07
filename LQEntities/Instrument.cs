using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace INOM.Entities
{
    public abstract class Instrument
    {

        ///// <summary>
        ///// 
        ///// </summary>
        //[Key]
        //public int InstrumentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int IdEspecie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductSubType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? IssuePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalIssued { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Issuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string AntiguedadPrecio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ComercializadoBGBA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string DesvioPrecio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string MarcaFinanciera { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CajaValor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SettleDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CodBancaPrivada { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Euroclear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ClearingHouseCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Common { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Dtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Mae { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Siscen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(5)]
        public string Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ActualizacionPrecio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Cusip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Exchange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Isin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CajaValorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Cedel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Industry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string TradingStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Ric { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Ticker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Afip { get; set; }

        public static List<Instrument> GetList(bool pendingAutorization)
        {
            var instruments = new List<Instrument>();

            for (int i = 0; i < 10; i++)
            {
                var inst = new InstrumentBond();
                inst.IdEspecie = i;

                instruments.Add(inst);
            }

            return instruments;
        }

        public static Instrument Get(int id)
        {
            return new InstrumentBond()
            {
                IdEspecie = id
            };
        }

        public static Instrument Save(Instrument instrumentMapper)
        {
            return instrumentMapper;
        }

        public static Instrument Update(Instrument instrumentMapper)
        {
            return instrumentMapper;
        }

        public static Instrument Verify(Instrument instrumentMapper)
        {
            return instrumentMapper;
        }

        public static Instrument Delete(Instrument instrumentMapper)
        {
            return instrumentMapper;
        }
    }
}
