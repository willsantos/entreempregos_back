using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;

namespace EntreEmpregos.Repository.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}