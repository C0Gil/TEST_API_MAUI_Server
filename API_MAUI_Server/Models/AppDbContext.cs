
using Microsoft.EntityFrameworkCore;

namespace API_MAUI_Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
    }
}
