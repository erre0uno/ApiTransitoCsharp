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
    public class MatriculaController : ControllerBase
    {
        #region PropiedadesConstructorContext
        private readonly TransitoDbContext _context;

        public MatriculaController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodoGet
        // GET: api/Matriculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        {
            return await _context.Matricula.ToListAsync();
        }
        #endregion

        #region MetodoGetID
        // GET: api/Matriculas/5
        [HttpGet("{numero}")]
        public async Task<ActionResult<Matricula>> GetMatricula(string numero)
        {
            var matricula = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }
        #endregion

        #region MetodoGetPut
        // PUT: api/Matriculas/5
        [HttpPut("{numero}")]
        public async Task<IActionResult> PutMatricula(string numero, Matricula matricula)
        {
            if (numero != matricula.Numero)
            {
                return BadRequest();
            }

            try
            {
                var entity = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);
                //entity.Id = matricula.Id;
                entity.Numero = matricula.Numero;
                entity.Expedicion = matricula.Expedicion;
                entity.Valido = matricula.Valido;
                entity.Activo = matricula.Activo;

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
        // POST: api/Matriculas
        [HttpPost]
        public async Task<HttpStatusCode> PostMatricula(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();

            return HttpStatusCode.Created;
        }
        #endregion

        #region MetodoGetDelete
        // DELETE: api/Matriculas/5
        [HttpDelete("{numero}")]
        public async Task<HttpStatusCode> DeleteMatricula(string numero)
        {
            var matricula = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);
            if (matricula == null)
            {
                return HttpStatusCode.BadRequest;
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion

    }
}
