using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRest.Data;
using APIRest.Models;
using System.Collections;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly APIRestContext _context;

        public PersonaController(APIRestContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        [Route("GetAllPersonas")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAllPersonas()
        {
            return await _context.Persona.ToListAsync();
        }

        [HttpGet]
        [Route("filtro")]
        public async Task<IEnumerable> FiltroEdad()
        {
            var listado = (from n in _context.Persona select n).OrderByDescending(x => x.Edad);
            return await listado.ToListAsync();
        }

        [HttpGet]
        [Route("personasbydistrito")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonaByDistrito(string dis)
        {
            var persona = _context.Persona.Where(p => p.Distrito.Equals(dis) && p.Activo == true).ToListAsync();
 
            return await persona;
        }


        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersonaById(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var estactivo = _context.Persona.Where(p => p.Id == id);
            foreach (var item in estactivo)
            {
                item.Activo = false;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.Id == id);
        }
    }
}
