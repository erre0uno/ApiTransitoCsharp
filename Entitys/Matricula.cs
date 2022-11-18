namespace ApiActividad.Entitys
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Matricula
    {

        public Matricula(){
            Conductores = new HashSet<Conductor>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Expedicion { get; set; }
       
        public DateTime Valido { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductores { get; set; }
    }
}
