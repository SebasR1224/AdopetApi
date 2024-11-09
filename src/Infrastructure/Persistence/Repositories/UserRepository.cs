using Application.Common.Interfaces.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
        => await context.Users.SingleOrDefaultAsync(x => x.Username == username);
}