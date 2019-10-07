using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class Parameter
    {
        public const string C_LAST_UPDATE_INSTRUMENTS = "LAST_UPDATE_DATE_INSTRUMENTS";

        public const string C_CALENDAR_YEARS = "CALYPSO_CALENDAR_YEARS";

        public const string SAP_SERVICE_ACCOUNT = "SAP_SERVICE_ACCOUNT";

        public const string SAP_SERVICE_ACCOUNT_ALWAYS = "SAP_SERVICE_ACCOUNT_ALWAYS";

        public const string FEEMGT_CONCEPTO = "FEEMGT_CONCEPTO";

        public const string ACDI_AUTH_MODE = "ACDI_AUTH_MODE";

        public const string INSTRUMENT_FROMDATE_INMONTH = "INSTRUMENT_FROMDATE_INMONTH";

        public const string INSTRUMENT_TODATE_INMONTH = "INSTRUMENT_TODATE_INMONTH";

        public const string C_LAST_UPDATE_INSTRUMENTS_BYMA = "LAST_UPDATE_INSTRUMENTS_BYMA";

        public const string BYMA_CONN_OPEN_MIN_BEFORE = "BYMA_CONN_OPEN_MIN_BEFORE";

        public const string C_LAST_UPDATE_INSTRUMENTS_MAE = "LAST_UPDATE_INSTRUMENTS_MAE";

        public const string MAE_CONN_OPEN_MIN_BEFORE = "MAE_CONN_OPEN_MIN_BEFORE";


        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        public int ParameterID { get; set; }
        /// <summary>
        /// Key del parametro.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Valor del parametro.
        /// </summary>
        public string Value { get; set; }

        public static void Save(Parameter parameters)
        {
            using (var db = new DBContext())
            {
                db.Parameters.Add(parameters);
                db.SaveChanges();
            }
        }

        public static void Update(Parameter parameters)
        {
            using (var db = new DBContext())
            {
                db.Parameters.Attach(parameters);
                db.Entry(parameters).Property(x => x.Value).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
