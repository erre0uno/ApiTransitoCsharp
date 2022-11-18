using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiActividad.DbContext;
using ApiActividad.Dto;
using ApiActividad.Entitys;
using System.Net;

namespace ApiActividad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SancionDTOController : ControllerBase
    {
        #region PropiedadesConstructor
        private readonly TransitoDbContext _context;
        #endregion

        #region Context
        public SancionDTOController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion


        #region MetodoGet
        // GET: api/SancionDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionDTOV>>> GetSancionDTO()
        {
            var sa = await _context.Sancion.Select(s =>
            new SancionDTOV
            {
                Tipo = s.Tipo,
                Observacion = s.Observacion,
                Valor = s.Valor,
                IdentificacionId = s.IdentificacionId
            }).ToListAsync();

            if (sa == null)
            {
                return NotFound();
            }
            else {
                return sa;
            }

        }
        #endregion


        #region MetodoGetID
        // GET: api/SancionDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionDTO>> GetSancionDTO(int id)
        {
            var sa = await _context.Sancion.FirstOrDefaultAsync(m => m.Id == id);
            if (sa == null)
            {
                return NotFound();
            }

            var saDTO = new SancionDTO
            {
                Id = sa.Id,
                Tipo = sa.Tipo,
                Observacion = sa.Observacion,
                Valor = sa.Valor,
                IdentificacionId = sa.IdentificacionId
            };
            return saDTO;
        }
        #endregion


        #region MetodoPut
        // PUT: api/SancionDTO/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutSancionDTO(int id, SancionDTO sancionDTO)
        {
            if (id != sancionDTO.Id)
            {
                return HttpStatusCode.BadRequest;
            }

            try
            {
                var entity = await _context.Sancion.FirstOrDefaultAsync(s => s.Id == id);
                entity.Id = sancionDTO.Id;
                entity.Tipo = sancionDTO.Tipo;
                entity.Observacion = sancionDTO.Observacion;
                entity.Valor = sancionDTO.Valor;
                entity.IdentificacionId = sancionDTO.IdentificacionId;

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


        #region MetodoPost
        // POST: api/SancionDTO
        [HttpPost]
        public async Task<HttpStatusCode> PostSancionDTO(SancionDTO sancionDTO)
        {
            try
            {
                var entity = new Sancion
                {
                    Id = sancionDTO.Id,
                    Tipo = sancionDTO.Tipo,
                    Observacion = sancionDTO.Observacion,
                    Valor = sancionDTO.Valor,
                    IdentificacionId = sancionDTO.IdentificacionId
            };
                _context.Sancion.Add(entity);
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
        // DELETE: api/SancionDTO/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteSancionDTO(int id)
        {
            var sancion = await _context.Sancion.FindAsync(id);
            if (sancion == null)
            {
                return HttpStatusCode.NotFound;
            }

            _context.Sancion.Remove(sancion);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion

    }
}
