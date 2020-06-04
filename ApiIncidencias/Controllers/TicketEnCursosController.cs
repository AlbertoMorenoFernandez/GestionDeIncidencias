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
    public class TicketEnCursosController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public TicketEnCursosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketEnCursos
        [HttpGet]
        public IEnumerable<TicketEnCurso> GetTicketEnCurso()
        {
            return _context.TicketEnCurso;
        }

        // GET: api/TicketEnCursos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketEnCurso([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketEnCurso = await _context.TicketEnCurso.FindAsync(id);

            if (ticketEnCurso == null)
            {
                return NotFound();
            }

            return Ok(ticketEnCurso);
        }

        // PUT: api/TicketEnCursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketEnCurso([FromRoute] int? id, [FromBody] TicketEnCurso ticketEnCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketEnCurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketEnCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketEnCursoExists(id))
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

        // POST: api/TicketEnCursos
        [HttpPost]
        public async Task<IActionResult> PostTicketEnCurso([FromBody] TicketEnCurso ticketEnCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TicketEnCurso.Add(ticketEnCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketEnCurso", new { id = ticketEnCurso.Id }, ticketEnCurso);
        }

        // DELETE: api/TicketEnCursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketEnCurso([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketEnCurso = await _context.TicketEnCurso.FindAsync(id);
            if (ticketEnCurso == null)
            {
                return NotFound();
            }

            _context.TicketEnCurso.Remove(ticketEnCurso);
            await _context.SaveChangesAsync();

            return Ok(ticketEnCurso);
        }

        private bool TicketEnCursoExists(int? id)
        {
            return _context.TicketEnCurso.Any(e => e.Id == id);
        }
    }
}