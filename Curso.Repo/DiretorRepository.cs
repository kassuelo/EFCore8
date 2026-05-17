using Curso.Domain.Entities;
using Curso.Repo.Contexts;
using Curso.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repo
{
    public class DiretorRepository(Context context) : IDiretorRepository
    {
        public async Task<IEnumerable<Diretor>> GetDiretores(CancellationToken ct = default)
        {
            return await context.Diretores
                .Include(d => d.Filmes)
                .ToListAsync(ct);
        }

        public async Task<Diretor?> GetDiretorByName(string nome, CancellationToken ct = default)
        {
            return await context.Diretores
                .Include(d => d.Filmes)
                .FirstOrDefaultAsync(d => d.Nome.Contains(nome), ct);
        }

        public async Task<Diretor?> GetDiretorById(int diretorId, CancellationToken ct = default)
        {
            return await context.Diretores
                .Include(d => d.Filmes)
                .FirstOrDefaultAsync(d => d.Id == diretorId, ct);
        }

        public Task Add(Diretor diretor)
        {
            //garante vinculo explícito
            if (diretor.Filmes is not null)
            {
                foreach (var filme in diretor.Filmes)
                {
                    filme.Diretor = diretor;
                }
            }
            context.Diretores.Add(diretor);

            return Task.CompletedTask;
        }

        public Task Update(Diretor diretor, Diretor input)
        {
            diretor.Nome = input.Nome;

            var filmesInput = input.Filmes ?? [];

            //remove filmes que não vieram no input
            var filmesParaRemover = diretor.Filmes
                .Where(f => filmesInput.All(i => i.Id != f.Id))
                .ToList();

            context.Filmes.RemoveRange(filmesParaRemover);

            //adiciona ou atualiza
            foreach (var filmeInput in filmesInput)
            {
                var filmeExistente = diretor.Filmes
                    .FirstOrDefault(f => f.Id == filmeInput.Id);

                if (filmeExistente is null)
                {
                    //novo 
                    diretor.Filmes.Add(new Filme
                    {
                        Titulo = filmeInput.Titulo,
                        Ano = filmeInput.Ano
                    });
                }
                else
                {
                    //atualiza
                    filmeExistente.Titulo = filmeInput.Titulo;
                    filmeExistente.Ano = filmeInput.Ano;

                }
            }
            return Task.CompletedTask;
        }

        public async Task<bool> Delete(int diretorId, CancellationToken ct = default)
        {
            var diretor = await GetDiretorById(diretorId, ct);

            if (diretor is null) return false;

            context.Diretores.Remove(diretor);

            return true;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await context.SaveChangesAsync(ct);
        }

    }
}
