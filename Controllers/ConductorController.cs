namespace ApiActividad.Controllers
{
    using ApiActividad.DbContext;
    using ApiActividad.Entitys;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        #region PropiedadesConstructorContext
        private readonly TransitoDbContext _context;
        public ConductorController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodoGet
        // GET: api/Conductor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conductor>>> GetConductor()
        {
            return await _context.Conductor.ToListAsync();
        }
        #endregion

        #region MetodoGetID
        // GET: api/Conductor/5
        [HttpGet("{identificacion}")]
        public async Task<ActionResult<Conductor>> GetConductor(string identificacion)
        {
            var conductor = await _context.Conductor.FirstOrDefaultAsync(c => c.Identificacion == identificacion);

            if (conductor == null)
            {
                return NotFound();
            }

            return conductor;
        }
        #endregion

        #region MetodoGetPut
        // PUT: api/Conductor/5
        [HttpPut("{identificacion}")]
        public async Task<IActionResult> PutConductor(string identificacion, Conductor conductor)
        {
            if (identificacion != conductor.Identificacion)
            {
                return BadRequest();
            }

            try
            {
                var entity = await _context.Conductor.FirstOrDefaultAsync(c => c.Identificacion == identificacion);
                entity.Id = conductor.Id;
                entity.Identificacion = conductor.Identificacion;
                entity.Nombre = conductor.Nombre;
                entity.Apellidos = conductor.Apellidos;
                entity.Direccion = conductor.Direccion;
                entity.Telefono = conductor.Telefono;
                entity.Correo = conductor.Correo;
                entity.FechaNacimiento = conductor.FechaNacimiento;
                entity.Activo = conductor.Activo;
                entity.MatriculaId = conductor.MatriculaId; 
                
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return NoContent();
        }
        #endregion

        #region MetodoGetPost
        // POST: api/Conductor
        [HttpPost]
        public async Task<HttpStatusCode> PostConductor(Conductor conductor)
        {
            _context.Conductor.Add(conductor);
            await _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }
        #endregion

        #region MetodoGetDelete
        // DELETE: api/Conductor/5
        [HttpDelete("{identificacion}")]
        public async Task<HttpStatusCode> DeleteConductor(string identificacion)
        {
            var conductor = await _context.Conductor.FirstOrDefaultAsync(c=>c.Identificacion == identificacion);
            if (conductor == null)
            {
                return HttpStatusCode.BadRequest;
            }

            _context.Conductor.Remove(conductor);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion

    }
}
