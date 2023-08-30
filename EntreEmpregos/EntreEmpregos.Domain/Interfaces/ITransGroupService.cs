using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface ITransGroupService
{
    Task<TransGroupResponse> AddAsync(TransGroupRequest request);
    Task<TransGroupResponse> UpdateAsync(Guid id, TransGroupRequest request);
    Task DeleteAsync(Guid id);
    Task<TransGroupResponse> GetAsync(Guid id);
    Task<IEnumerable<TransGroupResponse>> GetAllAsync();
}