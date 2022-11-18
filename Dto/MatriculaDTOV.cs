namespace ApiActividad.Dto
{
    using System;
    public class MatriculaDTOV
    {
        public string Numero { get; set; }
        public DateTime Expedicion { get; set; }

        public DateTime Valido { get; set; }
        public bool Activo { get; set; }

    }
}
