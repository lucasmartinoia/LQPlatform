namespace INOM.Entities
{
    public class BGBAHeader
    {
        public Identificadores Identificadores { get; set; }
        public ModuloAplicativo ModuloAplicativo { get; set; }
        public Origen Origen { get; set; }
    }
    public class Identificadores
    {
        public string IdMensaje { get; set; }
        public string IdOperacion { get; set; }
    }
    public class ModuloAplicativo
    {
        public string IdConsumidor { get; set; }
        public string IdGalicia { get; set; }
        public string IdProveedor { get; set; }
    }
    public class Origen
    {
        public string Canal { get; set; }
        public Equipo Equipo { get; set; }
        public IdCliente IdCliente { get; set; }
        public ModuloAplicativo ModuloAplicativo { get; set; }
        public Operador Operador { get; set; }
        public OrganizacionInterna OrganizacionInterna { get; set; }
    }
    public class Equipo
    {
        public string _ip { get; set; }
        public string _nombre { get; set; }
    }
    public class IdCliente
    {
        public string __text { get; set; }
        public string _idEsquema { get; set; }
    }
    public class Operador
    {
        public string __text { get; set; }
        public string _idEsquema { get; set; }
    }
    public class OrganizacionInterna
    {
        public string _id { get; set; }
        public string _tipo { get; set; }
    }
    public partial class BGBAResultadoOperacion
    {
        public string Severidad { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string tipo { get; set; }
        public string urlDetalle { get; set; }
        public IdRespuesta idRespuesta { get; set; }
    }
    public partial class IdRespuesta
    {
        public string nombreProveedor { get; set; }
    }

    public class bgbaoperationresultlog
    {
        public string logitem { get; set; }
    }

    public class Datos
    {
        public int InstructionID { get; set; }
    }
}
