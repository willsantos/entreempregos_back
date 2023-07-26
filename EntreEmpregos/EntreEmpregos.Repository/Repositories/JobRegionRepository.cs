using System.Linq.Expressions;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;

namespace EntreEmpregos.Repository.Repositories;

public class JobRegionRepository: BaseRepository<JobRegion>,IJobRegionRepository
{
    public JobRegionRepository(AppDbContext context) : base(context)
    {
    }
}