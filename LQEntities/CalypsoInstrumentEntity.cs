using System.Collections.Generic;

namespace INOM.Entities
{
    public class CalypsoInstrumentEntityResponse
    {
        public BGBAResultadoOperacion BGBAResultadoOperacion { get; set; }
        public ResultadoDatos Datos { get; set; }
    }
    public partial class ResultadoDatos
    {
        public Fondos fondos { get; set; }
    }
    public partial class Fondos
    {
        public List<CalypsoInstrumentEntity> fondo { get; set; }
    }
    public class CalypsoInstrumentEntity
    {
        public int Id { get; set; }//IdEspecie
        public string codigoEspecie { get; set; }//CodigoEspecie
        public string tipo { get; set; }//Tipo
        public string clase { get; set; }//Clase
        public string denominacion { get; set; }//Denominacion
        public string estado { get; set; }//Estado
        public string operativo { get; set; }//EsEspecieOperativa
        public string habilitaSuscripcion { get; set; }//HabilitaSuscripcion
        public string habilitaRescate { get; set; }//HabilitaRescate
        public string plazoRescate { get; set; }//PlazoRescate
        public string fechaAprobacion { get; set; }//FechaAprobacion
        public string divisaEmision { get; set; }
        public string fraccionMinima { get; set; }
        public string rangoDesde { get; set; }//RangoImporteDesde
        public string rangoHasta { get; set; }//RangoImporteHasta
        public string controlaFideicomiso { get; set; }//ControlaFideicomiso
        public string numeroInscripcion { get; set; }
        public string numeroResolucion499 { get; set; }
        public string composicionRiesgo { get; set; }
        public string clasificacion { get; set; }//Clasificacion
        public string montoMinimoSuscripcion { get; set; }//Clasificacion     
        public string denominacionDelFondo { get; set; }//Padre.PatrimonioFondo
        public string estadoDelFondo { get; set; }//padre.EstadoFondo
        public string fondoOperativo { get; set; }//Padre.EsFondoOperativo
        public string suscripcionInicialMinima { get; set; }//Padre.SuscripcionInicialMinima
        public string suscripcionInicialMaxima { get; set; }
        public string precio { get; set; }
        public string fechaDelPrecio { get; set; }//FechaPrecio
        public string patrimonioDelFondo { get; set; }
        public string ordenamiento { get; set; }//Ordenamiento
        public string porcentajeMaximoInversion { get; set; }//PorcentajeMaximoInversion
        public string monedaEmision { get; set; }//Moneda
        public string cuotas { get; set; }//ValorCuotaparte

    }


    //public class BGBAOperationResultLog
    //{
    //    public string cuotas { get; set; }
    //}
}
