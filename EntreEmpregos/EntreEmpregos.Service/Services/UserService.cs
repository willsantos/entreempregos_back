using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserResponse> AddAsync(UserRequest request)
    {
        ValidateRequest(request);
        var entity = _mapper.Map<User>(request);
        await _repository.AddAsync(entity);
        return _mapper.Map<UserResponse>(entity);
    }

    public async Task<UserResponse> UpdateAsync(Guid id, UserRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);
        entity.Name = request.Name;
        entity.Password = request.Password;

        await _repository.EditAsync(entity);
        return _mapper.Map<UserResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity);
    }

    public async Task<UserResponse> GetAsync(Guid id)
    {
        var entity = await GetById(id);
        return _mapper.Map<UserResponse>(entity);
    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var response = await _repository.ListAsync();
        if (!response.Any())
            throw new RecordNotFoundException("Nenhum usuario encontrado");
        return _mapper.Map<IEnumerable<UserResponse>>(response);
    }

    private async Task<User> GetById(Guid id)
    {
        var response = await _repository.FindAsync(id);
        if (response is null)
            throw new RecordNotFoundException("Usuário não encontrado");
        return response;
    }

    private static void ValidateRequest(UserRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}