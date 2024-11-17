using Domain.Users;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByUsernameOrEmailAsync(string username);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}