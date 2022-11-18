namespace ApiActividad.Entitys
{
    public class Sancion
    {

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }
        public string IdentificacionId { get; set; }

        //public virtual Conductor Identificacion { get; set;}

    }
}
