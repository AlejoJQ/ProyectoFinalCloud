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
    public class BLAutoresController : ControllerBase
    {
        private readonly DataContext _context;

        public BLAutoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BLAutores
        [Route("/BL/ReproduccionesTotal")]
        [HttpGet]
        public ActionResult<long> ReproduccionesTotal(int id_autor)
        {
            if (_context.Autores == null)
            {
                return NotFound();
            }

            long totalReproducciones = _context.Canciones
                .Join(_context.Autores,
                    c => c.Autorid_autor,
                    a => a.id_autor,
                    (c, a) => new { Cancion = c, Autor = a })
                .Where(ca => ca.Autor.id_autor == id_autor)
                .AsEnumerable()
                .Sum(ca => Convert.ToInt64(ca.Cancion.reproducciones));

            return totalReproducciones;
        }
    }
}
