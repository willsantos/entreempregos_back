using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;

namespace EntreEmpregos.Repository.Repositories;

public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
{
    public EmployerRepository(AppDbContext context) : base(context)
    {
    }
}