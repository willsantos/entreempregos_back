using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntreEmpregos.Repository.Context;

public class AppDbContext : DbContext
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobLevel> JobLevels { get; set; }
    public DbSet<JobRegion> JobRegions { get; set; }
    public DbSet<Employer> Employers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
}