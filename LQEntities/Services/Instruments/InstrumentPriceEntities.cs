using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace INOM.Entities.Services.Instruments
{
    public class InstrumentPriceRequest
    {
        public List<Product> Products { get; set; }
        public InstrumentPriceRequest()
        {
            Products = new List<Product>();
        }
    }

    public class Product
    {
        public string ProductCodeType { get; set; }
        public string ProductCode { get; set; }
        public string Market { get; set; }
        public string CodigoMoneda { get; set; }
        public int? Plazo { get; set; }
    }

    [XmlRoot(ElementName = "ListarCotizacionesDiariasResponse", Namespace = "http://ws.bancogalicia.com.ar/webservices/consultacotizacionesespecies/listarcotizacionesdiariasresponse/1_0_0")]
    public partial class ListarCotizacionesDiariasResponse
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://ws.bancogalicia.com.ar/webservices/globales/bgbaresultadooperacion/2_0_0")]
        public BGBAResultadoOperacion BGBAResultadoOperacion { get; set; }
        public DatosPrecios Datos { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://ws.bancogalicia.com.ar/webservices/globales/bgbaresultadooperacion/2_0_0")]
        public BGBAOperationBusResultLog BGBAOperationResultLog { get; set; }

        public ListarCotizacionesDiariasResponse()
        {
            BGBAResultadoOperacion = new BGBAResultadoOperacion();
            Datos = new DatosPrecios();
            BGBAOperationResultLog = new BGBAOperationBusResultLog();
        }
    }
    public class DatosPrecios
    {
        public List<Precio> Precios { get; set; }
    }
    public class Precio
    {
        public string IDCalypso { get; set; }
        public string Codigo { get; set; }
        public string IdListaCodigo { get; set; }
        public FuenteValuacion FuenteValuacion { get; set; }
    }
    public class FuenteValuacion
    {
        public string CodigoMercado { get; set; }
        public string CodigoMoneda { get; set; }
        public string Plazo { get; set; }
        public string CodigoFuente { get; set; }
        public string TipoPrecio { get; set; }
        public Cotizacion Cotizacion { get; set; }
    }
    public class Cotizacion
    {
        public string FechaCotizacion { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string BestBid { get; set; }
        public string BestAsk { get; set; }
        public string MidPrice { get; set; }
    }
    public class BGBAOperationBusResultLog
    {
        public string LogItem { get; set; }
    }
}
