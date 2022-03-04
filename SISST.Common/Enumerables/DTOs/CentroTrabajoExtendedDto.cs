namespace Comunes.DTOs
{
    public class CentroTrabajoExtendedDto
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveNombre => Clave + " - " + Nombre;
        public string ClaveControlGestion { get; set; }
        public string ClaveCTSuperior { get; set; }
        public int IdAreaSuperior { get; set; }
        public int IdNivelJerarquico { get; set; }
        public int Nivel { get; set; }
    }
}
