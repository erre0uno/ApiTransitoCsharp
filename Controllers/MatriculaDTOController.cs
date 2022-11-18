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
    public class MatriculaDTOController : ControllerBase
    {
        #region PropiedadesConstructorContext
        private readonly TransitoDbContext _context;

        public MatriculaDTOController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodoGet
        // GET: api/MatriculaDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTOV>>> GetMatriculaDTO()
        {
            var ma = await _context.Matricula.Select(m =>
            new MatriculaDTOV
            {
                Numero = m.Numero,
                Expedicion = m.Expedicion,
                Valido = m.Valido,
                Activo = m.Activo
            }).ToListAsync();
            if (ma == null)
            {
                return NotFound();
            }
            else { 
                return ma;
            }
        }
        #endregion

        #region MetodoGetID
        // GET: api/MatriculaDTO/5
        [HttpGet("{numero}")]
        public async Task<ActionResult<MatriculaDTO>> GetMatriculaDTO(string numero)
        {
            var ma = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);
            if (ma == null)
            {
                return NotFound();
            }

            var maDTO = new MatriculaDTO
            {
                Id = ma.Id,
                Numero = ma.Numero,
                Expedicion = ma.Expedicion,
                Valido = ma.Valido,
                Activo = ma.Activo
            };
                return maDTO;
        }
        #endregion

        #region MetodoGetPut
        // PUT: api/MatriculaDTO/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> PutMatriculaDTO(String numero, MatriculaDTO matriculaDTO)
        {
            if (numero != matriculaDTO.Numero)
            {
                return HttpStatusCode.BadRequest;
            }

            try
            {
                var entity = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);
                //entity.Id = matriculaDTO.Id;
                entity.Numero = matriculaDTO.Numero;
                entity.Expedicion = matriculaDTO.Expedicion;
                entity.Valido = matriculaDTO.Valido;
                entity.Activo = matriculaDTO.Activo;

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
        // POST: api/MatriculaDTO
        [HttpPost]
        public async Task<HttpStatusCode> PostMatriculaDTO(MatriculaDTO matriculaDTO)
        {
            try
            {
                var entity = new Matricula
                {
                    Id = matriculaDTO.Id,
                    Numero = matriculaDTO.Numero,
                    Expedicion = matriculaDTO.Expedicion,
                    Valido = matriculaDTO.Valido,
                    Activo = matriculaDTO.Activo
                };
                _context.Matricula.Add(entity);
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
        // DELETE: api/MatriculaDTO/5
        [HttpDelete("{numero}")]
        public async Task<HttpStatusCode> DeleteMatriculaDTO(string numero)
        {
            var matricula = await _context.Matricula.FirstOrDefaultAsync(m => m.Numero == numero);
            if (matricula == null)
            {
                return HttpStatusCode.NotFound;
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;

        }
        #endregion

    }
}
