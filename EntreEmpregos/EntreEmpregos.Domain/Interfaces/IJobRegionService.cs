using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobRegionService
{
    Task<JobRegionResponse> AddAsync(JobRegionRequest request);
    Task<JobRegionResponse> UpdateAsync(Guid id, JobRegionRequest request);
    Task DeleteAsync(Guid id);
    Task<JobRegionResponse> GetAsync(Guid id);
    Task<IEnumerable<JobRegionResponse>> GetAllAsync();
}