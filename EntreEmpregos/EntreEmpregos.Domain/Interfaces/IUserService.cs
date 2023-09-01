using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IUserService
{
    Task<UserResponse> AddAsync(UserRequest request);
    Task<UserResponse> UpdateAsync(Guid id, UserRequest request);
    Task DeleteAsync(Guid id);
    Task<UserResponse> GetAsync(Guid id);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<string> AuthenticateAsync(UserRequest request);
}