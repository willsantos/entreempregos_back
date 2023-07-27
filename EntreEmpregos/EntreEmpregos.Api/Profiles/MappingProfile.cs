using AutoMapper;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobRegionRequest, JobRegion>().ReverseMap();
        CreateMap<JobRegionResponse, JobRegion>().ReverseMap();
    }
}