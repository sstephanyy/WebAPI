using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // conversion the DepartamentoEnum property to STRING
            modelBuilder.Entity<Funcionario>()
                .Property(f => f.Departamento)
                .HasConversion<string>();

            modelBuilder.Entity<Funcionario>()
               .Property(f => f.Turno)
               .HasConversion<string>();
        }

    }
}
