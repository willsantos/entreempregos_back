using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class JobLevelService : IJobLevelService
{
    private readonly IMapper _mapper;
    private readonly IJobLevelRepository _repository;

    public JobLevelService(IMapper mapper, IJobLevelRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<JobLevelResponse> AddAsync(JobLevelRequest request)
    {
        ValidateRequest(request);


        var entity = _mapper.Map<JobLevel>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<JobLevelResponse>(entity);
    }

    public async Task<JobLevelResponse> UpdateAsync(Guid id,
        JobLevelRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);

        entity.Description = request.Description;

        await _repository.EditAsync(entity);

        return _mapper.Map<JobLevelResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity!);
    }

    public async Task<JobLevelResponse> GetAsync(Guid id)
    {
        var entity = await GetById(id);
        return _mapper.Map<JobLevelResponse>(entity);
    }

    public async Task<IEnumerable<JobLevelResponse>> GetAllAsync()
    {
        var entity = await _repository.ListAsync();
        if (!entity.Any())
            throw new RecordNotFoundException("Nenhum nivel encontrado");
        return _mapper.Map<IEnumerable<JobLevelResponse>>(entity);
    }

    private async Task<JobLevel?> GetById(Guid id)
    {
        var entity = await _repository.FindAsync(id);
        if (entity is null)
            throw new RecordNotFoundException("Nenhum nivel encontrado");
        return entity;
    }

    private static void ValidateRequest(JobLevelRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}