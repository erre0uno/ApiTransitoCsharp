namespace ApiActividad.Dto
{
    using System;
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Expedicion { get; set; }

        public DateTime Valido { get; set; }
        public bool Activo { get; set; }

    }
}
