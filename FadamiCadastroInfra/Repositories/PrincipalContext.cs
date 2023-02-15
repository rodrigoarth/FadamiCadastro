using FadamiCadastroInfra.Entities;
using Microsoft.EntityFrameworkCore;

namespace FadamiCadastroInfra.Context
{
    public class PrincipalContext : DbContext
    {
        public DbSet<Usuario>? Usuarios { get; set; }

        public PrincipalContext(DbContextOptions<PrincipalContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
