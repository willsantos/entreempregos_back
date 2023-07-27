using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobRegionService
{
    Task<JobRegionResponse> CriarAsync(JobRegionRequest request);
    Task<JobRegionResponse> AtualizarAsync(Guid? id, JobRegionRequest request);
    Task DeletarAsync(Guid id);
    Task<JobRegionResponse> ObterPorIdAsync(Guid id);
    Task<IEnumerable<JobRegionResponse>> ObterTodosAsync();
}