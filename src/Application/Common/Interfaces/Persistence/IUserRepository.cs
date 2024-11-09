using Domain.Users;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}