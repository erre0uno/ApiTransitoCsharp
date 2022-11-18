namespace ApiActividad.Controllers
{
    using ApiActividad.DbContext;
    using ApiActividad.Dto;
    using ApiActividad.Entitys;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class ConductorDTOController : ControllerBase
    {

        #region PropiedadesConstructorContext
        private readonly TransitoDbContext _context;

        public ConductorDTOController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodoGet
        // GET: api/ConductorDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTOV>>> GetConductorDTO()
        {
            var co = await _context.Conductor.Select(c =>
           new ConductorDTOV
           {
               Identificacion = c.Identificacion,
               Nombre = c.Nombre,
               Apellidos = c.Apellidos,
               Direccion = c.Direccion,
               Telefono = c.Telefono,
               Correo = c.Correo,
               FechaNacimiento = c.FechaNacimiento,
               Activo = c.Activo,
               MatriculaId = c.MatriculaId
               //Multas = c.Sanciones.Count()

           }).ToListAsync();
            if (co == null)
            {
                return NotFound();
            }
            else
            {
                return co;
            }
        }
        #endregion

        #region MetodoGetID
        // GET: api/ConductorDTO/5
        [HttpGet("{Identificacion}")]
        public async Task<ActionResult<ConductorDTOV>> GetConductorDTO(string Identificacion)
        {
            var co = await _context.Conductor.FirstOrDefaultAsync(c => c.Identificacion == Identificacion);
            if (co == null)
            {
                return NotFound();
            }

            var coDTO = new ConductorDTOV
            {
                Identificacion = co.Identificacion,
                Nombre = co.Nombre ,
                Apellidos = co.Apellidos ,
                Direccion = co.Direccion ,
                Telefono= co.Telefono,
                Correo = co.Correo,
                FechaNacimiento= co.FechaNacimiento,
                Activo=co.Activo,
                MatriculaId=co.MatriculaId
            };
            return coDTO;
        }
        #endregion

        #region MetodoGetPut
        // PUT: api/ConductorDTO/5
        [HttpPut("{identificacion}")]
        public async Task<HttpStatusCode> PutConductorDTO(string identificacion, ConductorDTO conductorDTO)
        {
            if (identificacion != conductorDTO.Identificacion)
            {
                return HttpStatusCode.BadRequest;
            }

            try
            {
                var entity = await _context.Conductor.FirstOrDefaultAsync(c => c.Identificacion == identificacion);
                //entity.Id = conductorDTO.Id;
                entity.Identificacion = conductorDTO.Identificacion;
                entity.Nombre = conductorDTO.Nombre;
                entity.Apellidos = conductorDTO.Apellidos;
                entity.Direccion = conductorDTO.Direccion;
                entity.Telefono = conductorDTO.Telefono;
                entity.Correo = conductorDTO.Correo;
                entity.FechaNacimiento = conductorDTO.FechaNacimiento;
                entity.Activo = conductorDTO.Activo;
                entity.MatriculaId = conductorDTO.MatriculaId; 

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region MetodoGetPost
        // POST: api/ConductorDTO
        [HttpPost]
        public async Task<HttpStatusCode> PostConductorDTO(ConductorDTO conductorDTO)
        {
            try
            {
                var entity = new Conductor
                {
                 Identificacion = conductorDTO.Identificacion,
                 Nombre = conductorDTO.Nombre,
                 Apellidos = conductorDTO.Apellidos,
                 Direccion = conductorDTO.Direccion,
                 Telefono = conductorDTO.Telefono,
                 Correo = conductorDTO.Correo,
                 FechaNacimiento = conductorDTO.FechaNacimiento,
                 Activo = conductorDTO.Activo,
                 MatriculaId = conductorDTO.MatriculaId,
            };
                _context.Conductor.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region MetodoGetDelete
        // DELETE: api/ConductorDTO/5
        [HttpDelete("{identificacion}")]
        public async Task<HttpStatusCode> DeleteConductorDTO(string identificacion)
        {
            var conductor = await _context.Conductor.FirstOrDefaultAsync(c=> c.Identificacion == identificacion);
            if (conductor == null)
            {
                return HttpStatusCode.NotFound;
            }

            _context.Conductor.Remove(conductor);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion

    }
}
