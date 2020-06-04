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

    public class TiposController : Controller
    {
        private readonly MySQLDbContext _context;

        public TiposController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Tipos
        [HttpGet]
        public IEnumerable<Tipo> GetTipo()
        {
            return _context.Tipo;
        }

        // GET: api/Tipos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return Ok(tipo);
        }

        // PUT: api/Tipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo([FromRoute] int id, [FromBody] Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo.Id)

            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        // POST: api/Tipos
        [HttpPost]
        public async Task<IActionResult> PostTipo([FromBody] Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tipo.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo", new { id = tipo.Id }, tipo);
        }

        // DELETE: api/Tipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();

            return Ok(tipo);
        }

        private bool TipoExists(int id)
        {
            return _context.Tipo.Any(e => e.Id == id);
        }
    }
}

