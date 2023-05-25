using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Disquera.Modelos;

namespace Disquera.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly DataContext _context;

        public CancionesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Canciones
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Cancion>>> GetCancion()
        {
          if (_context.Canciones == null)
          {
              return NotFound();
          }
            return await _context.Canciones.Include(a => a.Autor).ToListAsync();
        }*/
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCancion()
        {
            var canciones = await _context.Canciones
                .Include(c => c.Autor)
                .Select(c => new
                {
                    c.id_cancion,
                    c.nombre,
                    c.reproducciones,
                    id_autor = c.Autor.id_autor,
                    c.genero
                })
                .ToListAsync();

            if (_context.Canciones == null)
            {
                return NotFound();
            }

            return Ok(canciones);
        }

        // GET: api/Canciones/5
        [HttpGet("{id}")]
        /*public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
          if (_context.Canciones == null)
          {
              return NotFound();
          }
            var cancion = await _context.Canciones.FindAsync(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }*/
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
            if (_context.Canciones == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones
                .Select(c => new
                {
                    c.id_cancion,
                    c.nombre,
                    c.reproducciones,
                    c.genero,
                    id_autor = c.Autor.id_autor
                })
                .FirstOrDefaultAsync(c => c.id_cancion == id);

            if (cancion == null)
            {
                return NotFound();
            }

            return Ok(cancion);
        }

        // PUT: api/Canciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(int id, Cancion cancion)
        {
            if (id != cancion.id_cancion)
            {
                return BadRequest();
            }

            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Canciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
          if (_context.Canciones == null)
          {
              return Problem("Entity set 'DataContext.Cancion'  is null.");
          }
            _context.Canciones.Add(cancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancion", new { id = cancion.id_cancion }, cancion);
        }

        // DELETE: api/Canciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancion(int id)
        {
            if (_context.Canciones == null)
            {
                return NotFound();
            }
            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancionExists(int id)
        {
            return (_context.Canciones?.Any(e => e.id_cancion == id)).GetValueOrDefault();
        }
    }
}
