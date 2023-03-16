using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        //void Add(User user);
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task UpdateAsync(User user);
    }
}