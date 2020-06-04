using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiIncidencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public EquiposController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipos
        [HttpGet]
        public IEnumerable<Equipo> GetEquipo()
        {
            return _context.Equipo;
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipos([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipo = await _context.Equipo.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        // PUT: api/Equipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo([FromRoute] string id, [FromBody] Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipo.ServiceTag)

            {
                return BadRequest();
            }

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipos
        [HttpPost]
        public async Task<IActionResult> PostEquipo([FromBody] Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.ServiceTag }, equipo);
        }

        // DELETE: api/Equipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipo = await _context.Estado.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Estado.Remove(equipo);
            await _context.SaveChangesAsync();

            return Ok(equipo);
        }

        private bool EquipoExists(string id)
        {
            return _context.Equipo.Any(e => e.ServiceTag.Equals(id));
        }
    }
}
