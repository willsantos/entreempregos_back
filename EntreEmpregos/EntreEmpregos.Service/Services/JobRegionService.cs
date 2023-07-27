using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Interfaces;
using AutoMapper;
using EntreEmpregos.Api.Entities;

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


    public async Task<JobRegionResponse> CriarAsync(JobRegionRequest request)
    {
        if (request.Name is null)
            throw new ArgumentException("Nome não pode ser nulo");

        if (request.Abbr is null)
            throw new ArgumentException("Sigla não pode ser nula");

        var entity = _mapper.Map<JobRegion>(request);

        await _repository.AddAsync(entity);

        return _mapper.Map<JobRegionResponse>(entity);
    }

    public Task<JobRegionResponse> AtualizarAsync(Guid? id, JobRegionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeletarAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<JobRegionResponse> ObterPorIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<JobRegionResponse>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }
}