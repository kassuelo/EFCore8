using Curso.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.DbContexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Diretor> Diretores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EFCoreConsole.db");
        }
    }
}
