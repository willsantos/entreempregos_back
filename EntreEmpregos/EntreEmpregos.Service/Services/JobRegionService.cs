using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Interfaces;
using AutoMapper;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Exceptions;

namespace EntreEmpregos.Service.Services;

public class JobRegionService: IJobRegionService
{
    private readonly IMapper _mapper;
    private readonly IJobRegionRepository _repository;

    public JobRegionService(IMapper mapper, IJobRegionRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<JobRegionResponse> AddAsync(JobRegionRequest request)
    {
        ValidateRequest(request);


        var entity = _mapper.Map<JobRegion>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<JobRegionResponse>(entity);
    }



    public async Task<JobRegionResponse> UpdateAsync(Guid id, JobRegionRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);

        entity.Name = request.Name;
        entity.Abbr = request.Abbr;

        await _repository.EditAsync(entity);

        return _mapper.Map<JobRegionResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity!);
    }

    public async Task<JobRegionResponse> GetAsync(Guid id)
    {
        var entity = await GetById(id);
        
        

        return _mapper.Map<JobRegionResponse>(entity);
    }

    public async Task<IEnumerable<JobRegionResponse>> GetAllAsync()
    {
        var entity = await _repository.ListAsync();
        if (!entity.Any())
            throw new RecordNotFoundException("Nenhuma região encontrada");
        return _mapper.Map<IEnumerable<JobRegionResponse>>(entity);
    }
    
    private async Task<JobRegion?> GetById(Guid id)
    {
        var entity = await _repository.FindAsync(id);
        if (entity is null)
            throw new RecordNotFoundException("Região não encontrada");
        return entity;
    }
    
    private static void ValidateRequest(JobRegionRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}