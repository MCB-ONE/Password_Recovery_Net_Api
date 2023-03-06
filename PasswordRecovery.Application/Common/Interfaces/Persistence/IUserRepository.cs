using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(int id);
        User? GetByEmail(string email);
        void Update(User user);
    }
}