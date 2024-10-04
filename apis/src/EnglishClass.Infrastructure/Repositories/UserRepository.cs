using EnglishClass.Domain.Entities;
using EnglishClass.Infrastructure.Interfaces.Repositories;

namespace EnglishClass.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
