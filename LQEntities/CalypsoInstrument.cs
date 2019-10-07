using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class CalypsoInstrument
    {
        /// <summary>
        /// Id Calypso Funds.
        /// </summary>
        [Key]
        public int CalypsoInstrumentId { get; set; }
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Codigo Especie.
        /// </summary>
       // [Required]
        public string CodigoEspecie { get; set; }
        /// <summary>
        /// Tipo.
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Clase.
        /// </summary>
        public string Clase { get; set; }
        /// <summary>
        /// Nombre Reducido.
        /// </summary>
      //  public string NombreReducido { get; set; }
        /// <summary>
        /// Denominacion.
        /// </summary>
        public string Denominacion { get; set; }
        /// <summary>
        /// Estado.
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Operativo.
        /// </summary>
        public string Operativo { get; set; }
        /// <summary>
        /// Hab SusCripcion.
        /// </summary>
        public string HabilitaSusCripcion { get; set; }
        /// <summary>
        /// Hab Rescate.
        /// </summary>
        public string HabilitaRescate { get; set; }
        /// <summary>
        /// Llazo Rescate.
        /// </summary>
        public string PlazoRescate { get; set; }
        /// <summary>
        /// Fecha Aprobacion.
        /// </summary>
        public string FechaAprobacion { get; set; }
        /// <summary>
        /// Divisa Emision.
        /// </summary>
       // public string DivisaEmision { get; set; }
        /// <summary>
        /// Fraccion Minima.
        /// </summary>
     //   public float FraccionMinima { get; set; }
        /// <summary>
        /// Rango Desde.
        /// </summary>
        public string RangoDesde { get; set; }
        /// <summary>
        /// Rango Hasta.
        /// </summary>
        public string RangoHasta { get; set; }
        /// <summary>
        /// Controla Fideicomiso.
        /// </summary>
        public string ControlaFideicomiso { get; set; }
        /// <summary>
        /// Clasificacion.
        /// </summary>
        public string Clasificacion { get; set; }
        /// <summary>
        /// Denominacion Del Fondo.
        /// </summary>
        public string DenominacionDelFondo { get; set; }
        /// <summary>
        /// Estado Del Fondo.
        /// </summary>
        public string EstadoDelFondo { get; set; }
        /// <summary>
        /// Fondo Operativo.
        /// </summary>
        public string FondoOperativo { get; set; }
        /// <summary>
        /// Suscripcion Inicial Minima.
        /// </summary>
       // public int SuscripcionInicialMinima { get; set; }
        /// <summary>
        /// Suscripcion Inicial Maxima.
        /// </summary>
       // public int SuscripcionInicialMaxima { get; set; }
        /// <summary>
        /// Precio.
        /// </summary>
        public string Precio { get; set; }
        /// <summary>
        /// Fecha Del Precio.
        /// </summary>
        public string FechaDelPrecio { get; set; }
        /// <summary>
        /// Patrimonio Del Fondo.
        /// </summary>
        public string PatrimonioDelFondo { get; set; }
        /// <summary>
        /// Ordenamiento.
        /// </summary>
        public string Ordenamiento { get; set; }

        public string MonedaEmision { get; set; }
        public string NumeroInscripcion { get; set; }
        public string NumeroResolucion499 { get; set; }
        public string ComposicionRiesgo { get; set; }
        public string PorcentajeMaximoInversion { get; set; }
        public string MontoMinimoSuscripcion { get; set; }

        /// <summary>
        /// Save Fund Trade.
        /// </summary>
        public static void Save(CalypsoInstrument calypsoInstruments)
        {
            using (var db = new DBContext())
            {
                db.CalypsoInstruments.Add(calypsoInstruments);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Update Fund Trade.
        /// </summary>
        public static void Update(CalypsoInstrument calypsoInstruments)
        {
            using (var db = new DBContext())
            {
                db.CalypsoInstruments.Attach(calypsoInstruments);
                db.Entry(calypsoInstruments).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Update Fund Trade.
        /// </summary>
        public static void DeleteAll()
        {
            using (var db = new DBContext())
            {
                var allRec = db.CalypsoInstruments;
                db.CalypsoInstruments.RemoveRange(allRec);
                db.SaveChanges();
            }
        }

        public static CalypsoInstrument GetCalypsoInstrument(int id)
        {
            using (var db = new DBContext())
            {
                var res = db.CalypsoInstruments.Where(a => a.Id == id).FirstOrDefault();
                return res;
            }
        }
        /// <summary>
        /// Busqueda en Calypso de Especies por codigo de especies.
        /// </summary> 
        public static CalypsoInstrument GetCalypsoInstrumentByCode(string codigoEspecie)
        {
            using (var db = new DBContext())
            {
                var res = db.CalypsoInstruments.Where(a => a.CodigoEspecie == codigoEspecie).FirstOrDefault();
                return res;
            }
        }
    }
}
