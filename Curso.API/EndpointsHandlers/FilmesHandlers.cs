using Curso.Repo.Contexts;
using Curso.Domain.Entities;
using Curso.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.EndpointsHandler;

public class FilmesHandlers
{
    public static async Task<IResult> GetFilmes(Context context)
    {
        var filmes = await context.Filmes
            .Include(f => f.Diretor)
            .AsNoTracking()
            .OrderByDescending(f => f.Ano)
            .ThenBy(f => f.Titulo)
            .ToListAsync();

        return Results.Ok(filmes);
    }

    public static async Task<IResult> GetFilmeById(Context context, int id)
    {
        var filme = await context.Filmes
            .Include(f => f.Diretor)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        return filme is null
            ? Results.NotFound("Filme não encontrado")
            : Results.Ok(filme);
    }

    public static async Task<IResult> GetFilmesByNameEfFunction(Context context, string titulo)
    {
        var filmes = await context.Filmes
            .Where(f => EF.Functions.Like(f.Titulo, $"%{titulo}%"))
            .Include(f => f.Diretor)
            .AsNoTracking()
            .ToListAsync();

        return Results.Ok(filmes);
    }

    public static async Task<IResult> GetFilmesByNameLinq(Context context, string titulo)
    {
        var filmes = await context.Filmes
            .Where(f => f.Titulo.Contains(titulo))
            .Include(f => f.Diretor)
            .AsNoTracking()
            .ToListAsync();

        return Results.Ok(filmes);
    }

    public static async Task<IResult> DeleteFilme(Context context, int filmeId)
    {
        var linhasAfetadas = await context.Filmes
            .Where(f => f.Id == filmeId)
            .ExecuteDeleteAsync();

        return linhasAfetadas > 0
            ? Results.NoContent()
            : Results.NotFound("Filme não encontrado");
    }

    public static async Task<IResult> UpdateFilme(Context context, FilmeUpdate filmeUpdate)
    {
        var filme = await context.Filmes.FindAsync(filmeUpdate.Id);

        if (filme is null)
            return Results.NotFound("Filme não encontrado");

        filme.Titulo = filmeUpdate.Titulo;
        filme.Ano = filmeUpdate.Ano;

        await context.SaveChangesAsync();

        return Results.Ok("Filme atualizado com sucesso");
    }

    public static async Task<IResult> ExecuteUpdateFilme(Context context, FilmeUpdate filmeUpdate)
    {
        var linhasAfetadas = await context.Filmes
            .Where(f => f.Id == filmeUpdate.Id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
                .SetProperty(f => f.Ano, filmeUpdate.Ano));

        return linhasAfetadas > 0
            ? Results.Ok($"Você teve um total de {linhasAfetadas} linhas afetadas")
            : Results.NotFound("Filme não encontrado");
    }
}