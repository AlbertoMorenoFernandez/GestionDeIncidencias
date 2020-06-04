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

    public class LocalidadesController : Controller
    {
        private readonly MySQLDbContext _context;

        public LocalidadesController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Localidades
        [HttpGet]
        public IEnumerable<Localidad> GetLocalidad()
        {
            return _context.Localidad;
        }

        // GET: api/Localidades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalidades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var local = await _context.Localidad.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return Ok(local);
        }

        // PUT: api/Localidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad([FromRoute] int id, [FromBody] Localidad local)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != local.Id)

            {
                return BadRequest();
            }

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        // POST: api/Localidades
        [HttpPost]
        public async Task<IActionResult> PostEstado([FromBody] Localidad local)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Localidad.Add(local);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidad", new { id = local.Id }, local);
        }

        // DELETE: api/Localidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var local = await _context.Localidad.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Localidad.Remove(local);
            await _context.SaveChangesAsync();

            return Ok(local);
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidad.Any(e => e.Id == id);
        }
    }
}
