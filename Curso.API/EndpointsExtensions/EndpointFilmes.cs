using Curso.API.EndpointsHandler;

namespace Curso.API.Extensions;

public static class EndpointFilmes
{
    public static void FilmesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/filmes", FilmesHandlers.GetFilmes).WithOpenApi();

        app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeById).WithOpenApi();

        app.MapGet("/filmesEFFunction/byName/{titulo}", FilmesHandlers.GetFilmesByNameEfFunction).WithOpenApi();

        app.MapGet("/filmesLinQ/byName/{titulo}", FilmesHandlers.GetFilmesByNameLinq).WithOpenApi();

        app.MapDelete("/filmes/{filmeId}", FilmesHandlers.DeleteFilme).WithOpenApi();

        app.MapPatch("/filmesUpdate", FilmesHandlers.UpdateFilme).WithOpenApi();

        app.MapPatch("/filmesExecuteUpdate", FilmesHandlers.ExecuteUpdateFilme).WithOpenApi();
    }
}