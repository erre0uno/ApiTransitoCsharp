
namespace ApiActividad.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using ApiActividad.Entitys;

    public class TransitoDbContext: DbContext
    {
        public TransitoDbContext(DbContextOptions<TransitoDbContext> options) :
            base(options)
        {
        }

        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Sancion> Sancion { get; set; }
    }
}
