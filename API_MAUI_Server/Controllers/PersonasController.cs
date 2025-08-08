
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_MAUI_Server.Models;

namespace API_MAUI_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // Nuevo endpoint: Hola Mundo (GET)
        [HttpGet("holamundo")]  // Ruta: /api/personas/holamundo
        public IActionResult GetHolaMundo()
        {
            return Ok("¡Hola Mundo desde el PersonasController! 🌍");
        }
        

        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonas), new { id = persona.Id }, persona);
        }
    }
}
