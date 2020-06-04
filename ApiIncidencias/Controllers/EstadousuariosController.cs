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
    public class EstadousuariosController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public EstadousuariosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoUsuarios
        [HttpGet]
        public IEnumerable<EstadoUsuario> GetEstadoUsuario()
        {
            return _context.EstadoUsuario;
        }

        // GET: api/EstadoUsuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoUsuarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estado = await _context.EstadoUsuario.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/EstadoUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoUsuario([FromRoute] int id, [FromBody] EstadoUsuario estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.IdUsuario)

            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoUsuarioExists(id))
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

        // POST: api/EstadoUsuarios
        [HttpPost]
        public async Task<IActionResult> PostEstadoUsuario([FromBody] EstadoUsuario estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EstadoUsuario.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoUsuario", new { id = estado.IdUsuario }, estado);
        }

        // DELETE: api/EstadoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estado = await _context.EstadoUsuario.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.EstadoUsuario.Remove(estado);
            await _context.SaveChangesAsync();

            return Ok(estado);
        }

        private bool EstadoUsuarioExists(int id)
        {
            return _context.EstadoUsuario.Any(e => e.IdUsuario == id);
        }
    }
}
