using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EntreEmpregos.Repository.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<JobResponse> FindWithEmployerAsync(Guid id)
    {
        return await _context.Jobs
            .AsNoTracking()
            .Include(job => job.Employer)
            .Where(job => job.Id == id)
            .Select(job => new JobResponse
            {
                Id = job.Id,
                Publication = job.Publication,
                Position = job.Position,
                Format = job.Format,
                Contract = job.Contract,
                LevelId = job.LevelId,
                RegionId = job.RegionId,
                EmployerId = job.EmployerId,
                Employer = job.Employer.Name,
                Exclusivo = job.Exclusivo,
                Link = job.Link
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<object>> ListAllWithEmployerAsync()
    {
        return await _context.Jobs
            .AsNoTracking()
            .Include(job => job.Employer)
            .Select(job => new JobResponse
            {
                Id = job.Id,
                Publication = job.Publication,
                Position = job.Position,
                Format = job.Format,
                Contract = job.Contract,
                LevelId = job.LevelId,
                RegionId = job.RegionId,
                EmployerId = job.EmployerId,
                Employer = job.Employer.Name,
                Exclusivo = job.Exclusivo,
                Link = job.Link
            })
            .ToListAsync();
    }
}