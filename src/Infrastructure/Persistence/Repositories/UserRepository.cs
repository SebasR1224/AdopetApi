using Application.Common.Interfaces.Persistence;
using Domain.Users;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    public void Add(User user) => _users.Add(user);

    public async Task<User?> GetByUsernameAsync(string username)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Username == username);
    }
}