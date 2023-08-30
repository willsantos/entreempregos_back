using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;

namespace EntreEmpregos.Repository.Repositories;

public class JobLevelRepository : BaseRepository<JobLevel>, IJobLevelRepository
{
    public JobLevelRepository(AppDbContext context) : base(context)
    {
    }
}