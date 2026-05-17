using Curso.Repo.Contexts;
using Curso.API.EndpointsHandler;

namespace Curso.API.Extensions
{
    public static class EndpointDiretores
    {
        public static void DiretoresEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/diretores", DiretoresHandlers.GetDiretores).WithOpenApi();

            app.MapGet("/diretores/agregacao/{nome}", DiretoresHandlers.GetDiretorByName).WithOpenApi();

            app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretorById).WithOpenApi();

            app.MapPost("/diretores", DiretoresHandlers.CreateDiretor).WithOpenApi();

            app.MapPut("/diretores/{diretorId}", DiretoresHandlers.UpdateDiretor).WithOpenApi();

            app.MapDelete("/diretores/{diretorId}", DiretoresHandlers.DeleteDiretor).WithOpenApi();
        }
    }
}
