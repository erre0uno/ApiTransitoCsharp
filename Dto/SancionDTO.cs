namespace ApiActividad.Dto
{
    public class SancionDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }
        public string IdentificacionId { get; set; }
    }
}
