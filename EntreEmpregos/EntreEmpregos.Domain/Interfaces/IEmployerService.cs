using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IEmployerService
{
    Task<EmployerResponse> AddAsync(EmployerRequest request);
    Task<EmployerResponse> UpdateAsync(Guid id, EmployerRequest request);
    Task DeleteAsync(Guid id);
    Task<EmployerResponse> GetAsync(Guid id);
    Task<IEnumerable<EmployerResponse>> GetAllAsync();
}