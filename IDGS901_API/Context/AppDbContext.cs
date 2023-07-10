using IDGS901_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_API.Context
{
    public class AppDbContext:DbContext
    {
        private const string conectionstring="Conexion";
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        { }
        public DbSet<Alumnos> Alumnos { get; set; }

    }
}
