using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class JobService : IJobService
{
    private readonly IMapper _mapper;
    private readonly IJobRepository _repository;


    public JobService(IMapper mapper, IJobRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<JobResponse> AddAsync(JobRequest request)
    {
        ValidateRequest(request);


        var entity = _mapper.Map<Job>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<JobResponse>(entity);
    }

    public async Task<JobResponse> UpdateAsync(Guid id, JobRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);

        entity.Contract = request.Contract;
        entity.Position = request.Position;
        entity.Format = request.Format;
        entity.Link = request.Link;
        entity.Exclusivo = request.Exclusivo;


        await _repository.EditAsync(entity);

        return _mapper.Map<JobResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity);
    }

    public async Task<JobResponse> GetAsync(Guid id)
    {
        var entity = await _repository.FindWithEmployerAsync(id);
        return _mapper.Map<JobResponse>(entity);
    }

    public async Task<IEnumerable<JobResponse>> GetAllAsync()
    {
        var response = await _repository.ListAllWithEmployerAsync();
        if (!response.Any())
            throw new RecordNotFoundException("Nenhuma vaga encontrada");
        return _mapper.Map<IEnumerable<JobResponse>>(response);
    }

    private async Task<Job> GetById(Guid id)
    {
        var response = await _repository.FindAsync(id);
        if (response is null)
            throw new RecordNotFoundException("Vaga não encontrada");
        return response;
    }

    private static void ValidateRequest(JobRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}