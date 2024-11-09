using Application.Common.Interfaces.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public void Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public async Task<User?> GetByUsernameAsync(string username)
        => await context.Users.SingleOrDefaultAsync(x => x.Username == username);
}