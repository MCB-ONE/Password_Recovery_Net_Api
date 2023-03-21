using Microsoft.EntityFrameworkCore;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PasswordRevoceryDbContext _dbContext;

    public UserRepository(PasswordRevoceryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByVerifyTokenAsync(string token)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.VerificationToken == token);
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }
}
