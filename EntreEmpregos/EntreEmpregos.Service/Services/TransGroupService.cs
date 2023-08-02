using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Exceptions;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class TransGroupService : ITransGroupService
{
    private readonly IMapper _mapper;
    private readonly ITransGroupRepository _repository;

    public TransGroupService(IMapper mapper, ITransGroupRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<TransGroupResponse> AddAsync(TransGroupRequest request)
    {
        ValidateRequest(request);


        var entity = _mapper.Map<TransGroup>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<TransGroupResponse>(entity);
    }

    public async Task<TransGroupResponse> UpdateAsync(Guid id,
        TransGroupRequest request)
    {
        ValidateRequest(request);
        var entity = await GetById(id);

        entity.Name = request.Name;
        entity.GroupId = request.GroupId;

        await _repository.EditAsync(entity);

        return _mapper.Map<TransGroupResponse>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetById(id);
        await _repository.RemoveAsync(entity!);
    }

    public async Task<TransGroupResponse> GetAsync(Guid id)
    {
        var entity = await GetById(id);
        return _mapper.Map<TransGroupResponse>(entity);
    }

    public async Task<IEnumerable<TransGroupResponse>> GetAllAsync()
    {
        var entity = await _repository.ListAsync();
        if (!entity.Any())
            throw new RecordNotFoundException("Nenhum grupo encontrado");
        return _mapper.Map<IEnumerable<TransGroupResponse>>(entity);
    }

    private async Task<TransGroup?> GetById(Guid id)
    {
        var entity = await _repository.FindAsync(id);
        if (entity is null)
            throw new RecordNotFoundException("Grupo não encontrado");
        return entity;
    }

    private static void ValidateRequest(TransGroupRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }
}