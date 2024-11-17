using Domain.PasswordRecovery;

namespace Application.Common.Interfaces.Persistence;

public interface IPasswordRecoveryTokenRepository
{
    Task AddAsync(PasswordRecoveryToken passwordRecoveryToken);
    Task<PasswordRecoveryToken?> GetByTokenAsync(string token);
    Task UpdateAsync(PasswordRecoveryToken passwordRecoveryToken);
}