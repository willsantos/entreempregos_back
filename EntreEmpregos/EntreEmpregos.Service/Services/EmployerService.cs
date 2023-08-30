using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class EmployerService : IEmployerService
{
    private readonly IMapper _mapper;
    private readonly IEmployerRepository _repository;

    public EmployerService(IMapper mapper, IEmployerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EmployerResponse> AddAsync(EmployerRequest request)
    {
        ValidateRequest(request);


        var entity = _mapper.Map<Employer>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<EmployerResponse>(entity);
    }

    public async Task<EmployerResponse> UpdateAsync(Guid id,
        EmployerRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);

        entity.Name = request.Name;

        await _repository.EditAsync(entity);

        return _mapper.Map<EmployerResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity!);
    }

    public async Task<EmployerResponse> GetAsync(Guid id)
    {
        var entity = await GetById(id);
        return _mapper.Map<EmployerResponse>(entity);
    }

    public async Task<IEnumerable<EmployerResponse>> GetAllAsync()
    {
        var entity = await _repository.ListAsync();
        if (!entity.Any())
            throw new RecordNotFoundException("Nenhuma empresa encontrada");
        return _mapper.Map<IEnumerable<EmployerResponse>>(entity);
    }

    private async Task<Employer?> GetById(Guid id)
    {
        var entity = await _repository.FindAsync(id);
        if (entity is null)
            throw new RecordNotFoundException("Empresa não encontrada");
        return entity;
    }

    private static void ValidateRequest(EmployerRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}