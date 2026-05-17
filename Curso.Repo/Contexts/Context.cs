using Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repo.Contexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Diretor> Diretores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>()
                .HasMany(e => e.Filmes)
                .WithOne(e => e.Diretor)
                .HasForeignKey(e => e.DiretorId)
                .IsRequired();

            modelBuilder.Entity<Diretor>().HasData(
                new Diretor { Id = 1, Nome = "Steven Spielberg" },
                new Diretor { Id = 2, Nome = "Christopher Nolan" },
                new Diretor { Id = 3, Nome = "Quentin Tarantino" },
                new Diretor { Id = 4, Nome = "Martin Scorsese" },
                new Diretor { Id = 5, Nome = "James Cameron" },
                new Diretor { Id = 6, Nome = "Ridley Scott" },
                new Diretor { Id = 7, Nome = "Peter Jackson" },
                new Diretor { Id = 8, Nome = "Tim Burton" },
                new Diretor { Id = 9, Nome = "Clint Eastwood" },
                new Diretor { Id = 10, Nome = "David Fincher" }
           );

            modelBuilder.Entity<Filme>().HasData(
                new Filme { Id = 1, Titulo = "Inception", Ano = 2010, DiretorId = 2 },
                new Filme { Id = 2, Titulo = "Interstellar", Ano = 2014, DiretorId = 2 },
                new Filme { Id = 3, Titulo = "Dunkirk", Ano = 2017, DiretorId = 2 },
                new Filme { Id = 4, Titulo = "Pulp Fiction", Ano = 1994, DiretorId = 3 },
                new Filme { Id = 5, Titulo = "Kill Bill Vol. 1", Ano = 2003, DiretorId = 3 },
                new Filme { Id = 6, Titulo = "Kill Bill Vol. 2", Ano = 2004, DiretorId = 3 },
                new Filme { Id = 7, Titulo = "The Wolf of Wall Street", Ano = 2013, DiretorId = 4 },
                new Filme { Id = 8, Titulo = "Taxi Driver", Ano = 1976, DiretorId = 4 },
                new Filme { Id = 9, Titulo = "Goodfellas", Ano = 1990, DiretorId = 4 },
                new Filme { Id = 10, Titulo = "Avatar", Ano = 2009, DiretorId = 5 },
                new Filme { Id = 11, Titulo = "Titanic", Ano = 1997, DiretorId = 5 },
                new Filme { Id = 12, Titulo = "Aliens", Ano = 1986, DiretorId = 5 },
                new Filme { Id = 13, Titulo = "Gladiator", Ano = 2000, DiretorId = 6 },
                new Filme { Id = 14, Titulo = "Alien", Ano = 1979, DiretorId = 6 },
                new Filme { Id = 15, Titulo = "Blade Runner", Ano = 1982, DiretorId = 6 },
                new Filme { Id = 16, Titulo = "The Lord of the Rings: The Fellowship of the Ring", Ano = 2001, DiretorId = 7 },
                new Filme { Id = 17, Titulo = "The Lord of the Rings: The Two Towers", Ano = 2002, DiretorId = 7 },
                new Filme { Id = 18, Titulo = "The Lord of the Rings: The Return of the King", Ano = 2003, DiretorId = 7 },
                new Filme { Id = 19, Titulo = "Edward Scissorhands", Ano = 1990, DiretorId = 8 },
                new Filme { Id = 20, Titulo = "Beetlejuice", Ano = 1988, DiretorId = 8 },
                new Filme { Id = 21, Titulo = "Batman", Ano = 1989, DiretorId = 8 },
                new Filme { Id = 22, Titulo = "Gran Torino", Ano = 2008, DiretorId = 9 },
                new Filme { Id = 23, Titulo = "Million Dollar Baby", Ano = 2004, DiretorId = 9 },
                new Filme { Id = 24, Titulo = "Unforgiven", Ano = 1992, DiretorId = 9 },
                new Filme { Id = 25, Titulo = "Fight Club", Ano = 1999, DiretorId = 10 },
                new Filme { Id = 26, Titulo = "Se7en", Ano = 1995, DiretorId = 10 },
                new Filme { Id = 27, Titulo = "Gone Girl", Ano = 2014, DiretorId = 10 },
                new Filme { Id = 28, Titulo = "Jurassic Park", Ano = 1993, DiretorId = 1 },
                new Filme { Id = 29, Titulo = "E.T.", Ano = 1982, DiretorId = 1 },
                new Filme { Id = 30, Titulo = "Schindler's List", Ano = 1993, DiretorId = 1 },
                new Filme { Id = 31, Titulo = "Catch Me If You Can", Ano = 2002, DiretorId = 1 },
                new Filme { Id = 32, Titulo = "The Terminal", Ano = 2004, DiretorId = 1 },
                new Filme { Id = 33, Titulo = "War of the Worlds", Ano = 2005, DiretorId = 1 },
                new Filme { Id = 34, Titulo = "The Hateful Eight", Ano = 2015, DiretorId = 3 },
                new Filme { Id = 35, Titulo = "Inglourious Basterds", Ano = 2009, DiretorId = 3 },
                new Filme { Id = 36, Titulo = "Shutter Island", Ano = 2010, DiretorId = 4 },
                new Filme { Id = 37, Titulo = "The Departed", Ano = 2006, DiretorId = 4 },
                new Filme { Id = 38, Titulo = "The Aviator", Ano = 2004, DiretorId = 4 },
                new Filme { Id = 39, Titulo = "Prometheus", Ano = 2012, DiretorId = 6 },
                new Filme { Id = 40, Titulo = "The Martian", Ano = 2015, DiretorId = 6 },
                new Filme { Id = 41, Titulo = "The Hobbit: An Unexpected Journey", Ano = 2012, DiretorId = 7 },
                new Filme { Id = 42, Titulo = "The Hobbit: The Desolation of Smaug", Ano = 2013, DiretorId = 7 },
                new Filme { Id = 43, Titulo = "The Hobbit: The Battle of the Five Armies", Ano = 2014, DiretorId = 7 },
                new Filme { Id = 44, Titulo = "Big Fish", Ano = 2003, DiretorId = 8 },
                new Filme { Id = 45, Titulo = "Charlie and the Chocolate Factory", Ano = 2005, DiretorId = 8 },
                new Filme { Id = 46, Titulo = "American Sniper", Ano = 2014, DiretorId = 9 },
                new Filme { Id = 47, Titulo = "Mystic River", Ano = 2003, DiretorId = 9 },
                new Filme { Id = 48, Titulo = "Zodiac", Ano = 2007, DiretorId = 10 },
                new Filme { Id = 49, Titulo = "The Social Network", Ano = 2010, DiretorId = 10 },
                new Filme { Id = 50, Titulo = "The Girl with the Dragon Tattoo", Ano = 2011, DiretorId = 10 }
            );
        }
    }
}
