using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobLevelService
{
    Task<JobLevelResponse> AddAsync(JobLevelRequest request);
    Task<JobLevelResponse> UpdateAsync(Guid id, JobLevelRequest request);
    Task DeleteAsync(Guid id);
    Task<JobLevelResponse> GetAsync(Guid id);
    Task<IEnumerable<JobLevelResponse>> GetAllAsync();
}