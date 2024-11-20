
using procedimientos_almacenados_API.Models;
using Microsoft.EntityFrameworkCore;

namespace procedimientos_almacenados_API
{
    public class PruebaContext : DbContext
    {

        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEmpleadoDto>().HasNoKey(); 
        }

    }
}
