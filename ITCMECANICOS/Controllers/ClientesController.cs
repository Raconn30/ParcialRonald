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
    public class ClientesController : ControllerBase
    {
        private readonly ItcmecanicosContext _context;

        public ClientesController(ItcmecanicosContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesMV>>> GetEstudiantes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var query = from clientes in await _context.Clientes.ToListAsync()
                        select new ClientesMV
                        {
                            Codigo = clientes.Id,
                            Nombre = clientes.Nombre,
                            Apellido = clientes.Apellido,
                            Telefono = clientes.Telefono,
                            Email = clientes.Email
                        };
            return query.ToList();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
          if (_context.Clientes == null)
          {
              return Problem("Entity set 'ItcmecanicosContext.Clientes'  is null.");
          }
            _context.Clientes.Add(cliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
