using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobService
{
    Task<JobResponse> AddAsync(JobRequest request);
    Task<JobResponse> UpdateAsync(Guid id, JobRequest request);
    Task DeleteAsync(Guid id);
    Task<JobResponse> GetAsync(Guid id);
    Task<IEnumerable<JobResponse>> GetAllAsync();
}