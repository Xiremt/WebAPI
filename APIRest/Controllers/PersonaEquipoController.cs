using APIRest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.Entity;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaEquipoController : ControllerBase
    {
        private readonly APIRestContext _context;

        public PersonaEquipoController(APIRestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IEnumerable> GetAll()
        {
            var mydata = await _context.Persona.Join(_context.Equipo, p => p.IdEquipo, e => e.Id, (p, e) => new { p, e }).Select(result => new
            {
                result.p.Id,
                result.p.Apellido,
                result.e.Color
            }).ToListAsync();

            return mydata;
        }
    }
}
