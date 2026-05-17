
using Curso.Domain.Entities;
using Curso.Repo.Contratos;

namespace Curso.API.EndpointsHandler
{
    public class DiretoresHandlers
    {

        public static async Task<IResult> GetDiretores(IDiretorRepository diretorRepository, CancellationToken ct)
        {
            var diretores = await diretorRepository.GetDiretores(ct);

            return Results.Ok(diretores);
        }

        public static async Task<IResult> GetDiretorByName(IDiretorRepository diretorRepository, string nome, CancellationToken ct)
        {
            var diretor = await diretorRepository.GetDiretorByName(nome, ct);

            return diretor is null
              ? Results.NotFound("Diretor não encontrado")
              : Results.Ok(diretor);
        }

        public static async Task<IResult> GetDiretorById(IDiretorRepository diretorRepository, int id, CancellationToken ct)
        {
            var diretor = await diretorRepository.GetDiretorById(id, ct);

            return diretor is null
                ? Results.NotFound("Diretor não encontrado")
                : Results.Ok(diretor);
        }

        public static async Task<IResult> CreateDiretor(IDiretorRepository diretorRepository, Diretor diretor, CancellationToken ct)
        {
            await diretorRepository.Add(diretor);

            await diretorRepository.SaveChangesAsync(ct);

            return Results.Created($"/diretor/{diretor.Id}", diretor);
        }

        public static async Task<IResult> UpdateDiretor(IDiretorRepository diretorRepository, int diretorId, Diretor input, CancellationToken ct)
        {
            var diretor = await diretorRepository.GetDiretorById(diretorId, ct);

            if (diretor is null)
                return Results.NotFound();

            await diretorRepository.Update(diretor, input);

            await diretorRepository.SaveChangesAsync(ct);

            return Results.Ok("Diretor atualizado com sucesso");
        }

        public static async Task<IResult> DeleteDiretor(IDiretorRepository diretorRepository, int diretorId, CancellationToken ct)
        {
            var removed = await diretorRepository.Delete(diretorId, ct);

            if (!removed) return Results.NotFound();

            await diretorRepository.SaveChangesAsync(ct);

            return Results.NoContent();
        }
    }
}
