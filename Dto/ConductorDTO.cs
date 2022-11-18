namespace ApiActividad.Dto
{
    using System;
    public class ConductorDTO
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; } = true;
        public string MatriculaId { get; set; }

    }
}
