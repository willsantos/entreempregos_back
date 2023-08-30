using AutoMapper;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobRegionRequest, JobRegion>().ReverseMap();
        CreateMap<JobRegionResponse, JobRegion>().ReverseMap();
        CreateMap<JobLevelRequest, JobLevel>().ReverseMap();
        CreateMap<JobLevelResponse, JobLevel>().ReverseMap();
        CreateMap<EmployerRequest, Employer>().ReverseMap();
        CreateMap<EmployerResponse, Employer>().ReverseMap();
        CreateMap<TransGroupRequest, TransGroup>().ReverseMap();
        CreateMap<TransGroupResponse, TransGroup>().ReverseMap();
        CreateMap<JobRequest, Job>().ReverseMap();
        CreateMap<JobResponse, Job>().ReverseMap();
    }
}