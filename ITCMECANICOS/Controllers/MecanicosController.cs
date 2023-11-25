using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITCMECANICOS.Models;
using ITCMECANICOS.ModelsView;

namespace ITCMECANICOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicosController : ControllerBase
    {
        private readonly ItcmecanicosContext _context;

        public MecanicosController(ItcmecanicosContext context)
        {
            _context = context;
        }

        // GET: api/Mecanicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MecanicosMV>>> GetEstudiantes()
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }
            var query = from mecanicos in await _context.Mecanicos.ToListAsync()
                        select new MecanicosMV
                        {
                            Codigo = mecanicos.Id,
                            Nombre = mecanicos.Nombre,
                            Apellido = mecanicos.Apellido,
                            Telefono = mecanicos.Telefono,
                            Email = mecanicos.Email
                        };
            return query.ToList();
        }

        // GET: api/Mecanicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanico>> GetMecanico(int id)
        {
          if (_context.Mecanicos == null)
          {
              return NotFound();
          }
            var mecanico = await _context.Mecanicos.FindAsync(id);

            if (mecanico == null)
            {
                return NotFound();
            }

            return mecanico;
        }

        // PUT: api/Mecanicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanico(int id, Mecanico mecanico)
        {
            if (id != mecanico.Id)
            {
                return BadRequest();
            }

            _context.Entry(mecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecanicoExists(id))
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

        // POST: api/Mecanicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        {
          if (_context.Mecanicos == null)
          {
              return Problem("Entity set 'ItcmecanicosContext.Mecanicos'  is null.");
          }
            _context.Mecanicos.Add(mecanico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MecanicoExists(mecanico.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMecanico", new { id = mecanico.Id }, mecanico);
        }

        // DELETE: api/Mecanicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanico(int id)
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }
            var mecanico = await _context.Mecanicos.FindAsync(id);
            if (mecanico == null)
            {
                return NotFound();
            }

            _context.Mecanicos.Remove(mecanico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MecanicoExists(int id)
        {
            return (_context.Mecanicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
