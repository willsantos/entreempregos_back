using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;

namespace EntreEmpregos.Repository.Repositories;

public class TransGroupRepository : BaseRepository<TransGroup>,
    ITransGroupRepository
{
    public TransGroupRepository(AppDbContext context) : base(context)
    {
    }
}