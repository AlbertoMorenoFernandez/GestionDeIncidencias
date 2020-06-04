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
    public class TecnicosController : Controller
    {
        private readonly MySQLDbContext _context;

        public TecnicosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Tecnicos
        [HttpGet]
        public IEnumerable<Tecnico> GetTecnico()
        {
            return _context.Tecnico;
        }

        // GET: api/Tecnicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTecnicos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tecnico = await _context.Tecnico.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return Ok(tecnico);
        }

        // PUT: api/Tecnicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo([FromRoute] int id, [FromBody] Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecnico.IdUsuario)

            {
                return BadRequest();
            }

            _context.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnicos
        [HttpPost]
        public async Task<IActionResult> PostTecnico([FromBody] Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tecnico.Add(tecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTecnico", new { id = tecnico.IdUsuario }, tecnico);
        }

        // DELETE: api/Tecnicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tecnico = await _context.Tecnico.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            _context.Tecnico.Remove(tecnico);
            await _context.SaveChangesAsync();

            return Ok(tecnico);
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnico.Any(e => e.IdUsuario == id);
        }

    }
}
