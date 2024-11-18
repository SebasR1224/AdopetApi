using Application.Common.Interfaces.Persistence;
using Domain.PasswordRecovery;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PasswordRecoveryTokenRepository(ApplicationDbContext dbContext) : IPasswordRecoveryTokenRepository
{
    public async Task AddAsync(PasswordRecoveryToken passwordRecoveryToken)
    {
        dbContext.PasswordRecoveryTokens.Add(passwordRecoveryToken);
        await dbContext.SaveChangesAsync();
    }

    public async Task<PasswordRecoveryToken?> GetByTokenAsync(string token) =>
        await dbContext.PasswordRecoveryTokens.FirstOrDefaultAsync(x => x.Token == token);

    public async Task UpdateAsync(PasswordRecoveryToken passwordRecoveryToken)
    {
        dbContext.PasswordRecoveryTokens.Update(passwordRecoveryToken);
        await dbContext.SaveChangesAsync();
    }
}