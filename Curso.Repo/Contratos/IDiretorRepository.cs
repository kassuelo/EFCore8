using Curso.Domain.Entities;

namespace Curso.Repo.Contratos
{
    public interface IDiretorRepository
    {
        Task<IEnumerable<Diretor>> GetDiretores(CancellationToken ct = default);
        Task<Diretor?> GetDiretorByName(string nome, CancellationToken ct = default);
        Task<Diretor?> GetDiretorById(int diretorId, CancellationToken ct = default);
        Task Add(Diretor diretor);
        Task Update(Diretor diretor, Diretor input);
        Task<bool> Delete(int diretorId, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}