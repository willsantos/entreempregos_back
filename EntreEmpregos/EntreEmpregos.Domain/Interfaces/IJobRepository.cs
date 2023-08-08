using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Domain.Interfaces;

public interface IJobRepository : IBaseRepository<Job>
{
    Task<IEnumerable<dynamic>> ListAllWithEmployerAsync();
}