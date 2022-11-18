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
    public class SancionController : ControllerBase
    {
        #region PropiedadesConstructorContext
        private readonly TransitoDbContext _context;

        public SancionController(TransitoDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodoGet
        // GET: api/Sancion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sancion>>> GetSancion()
        {
            return await _context.Sancion.ToListAsync();
        }
        #endregion

        #region MetodoGetID
        // GET: api/Sancion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sancion>> GetSancion(int id)
        {
            var sancion = await _context.Sancion.FindAsync(id);

            if (sancion == null)
            {
                return NotFound();
            }

            return sancion;
        }
        #endregion

        #region MetodoGetPut
        // PUT: api/Sancion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSancion(int id, Sancion sancion)
        {
            if (id != sancion.Id)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(sancion).State = EntityState.Modified;
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
        // POST: api/Sancion
        [HttpPost]
        public async Task<HttpStatusCode> PostSancion(Sancion sancion)
        {
            _context.Sancion.Add(sancion);
            await _context.SaveChangesAsync();

            return HttpStatusCode.Created;
        }
        #endregion

        #region MetodoGetDelete
        // DELETE: api/Sancion/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteSancion(int id)
        {
            var sancion = await _context.Sancion.FindAsync(id);
            if (sancion == null)
            {
                return HttpStatusCode.BadRequest;
            }

            _context.Sancion.Remove(sancion);
            await _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }
        #endregion

    }
}
