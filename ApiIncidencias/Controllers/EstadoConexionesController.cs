using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiIncidencias.Models;

namespace ApiIncidencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConexionesController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public EstadoConexionesController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoConexiones
        [HttpGet]
        public IEnumerable<EstadoConexion> GetEstadoConexion()
        {
            return _context.EstadoConexion;
        }

        // GET: api/EstadoConexiones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoConexion([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoConexion = await _context.EstadoConexion.FindAsync(id);

            if (estadoConexion == null)
            {
                return NotFound();
            }

            return Ok(estadoConexion);
        }

        // PUT: api/EstadoConexiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoConexion([FromRoute] int? id, [FromBody] EstadoConexion estadoConexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoConexion.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoConexion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoConexionExists(id))
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

        // POST: api/EstadoConexiones
        [HttpPost]
        public async Task<IActionResult> PostEstadoConexion([FromBody] EstadoConexion estadoConexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EstadoConexion.Add(estadoConexion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoConexion", new { id = estadoConexion.Id }, estadoConexion);
        }

        // DELETE: api/EstadoConexiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoConexion([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoConexion = await _context.EstadoConexion.FindAsync(id);
            if (estadoConexion == null)
            {
                return NotFound();
            }

            _context.EstadoConexion.Remove(estadoConexion);
            await _context.SaveChangesAsync();

            return Ok(estadoConexion);
        }

        private bool EstadoConexionExists(int? id)
        {
            return _context.EstadoConexion.Any(e => e.Id == id);
        }
    }
}