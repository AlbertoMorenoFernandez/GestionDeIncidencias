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
    public class SedesController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public SedesController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Sedes
        [HttpGet]
        public IEnumerable<Sede> GetSede()
        {
            return _context.Sede;
        }

        // GET: api/Sedes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSedes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sede = await _context.Sede.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return Ok(sede);
        }

        // PUT: api/Sedes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede([FromRoute] int id, [FromBody] Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sede.NumOficina)

            {
                return BadRequest();
            }

            _context.Entry(sede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes
        [HttpPost]
        public async Task<IActionResult> PostSede([FromBody] Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sede.Add(sede);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSede", new { id = sede.NumOficina }, sede);
        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sede = await _context.Sede.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sede.Remove(sede);
            await _context.SaveChangesAsync();

            return Ok(sede);
        }

        private bool SedeExists(int id)
        {
            return _context.Sede.Any(e => e.NumOficina == id);
        }
    }
}
