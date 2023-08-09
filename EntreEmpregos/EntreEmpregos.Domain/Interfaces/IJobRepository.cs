using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobRepository : IBaseRepository<Job>
{
    Task<IEnumerable<dynamic>> ListAllWithEmployerAsync();
    Task<JobResponse> FindWithEmployerAsync(Guid id);
}