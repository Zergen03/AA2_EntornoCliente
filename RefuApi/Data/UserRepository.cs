using RefuApi.Data.Intefaces;
using User = RefuApi.Models.User;
using RefuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RefuApi.Data;

public class UserRepository : IUserRepository
{
    private readonly RefuApiContext _context;

    public UserRepository(RefuApiContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public Task Delete(User user)
    {
        _context.Users.Remove(user);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<User>> GetAll(UserQueryParameters? userQueryParameters)
    {
        var query = _context.Users.AsQueryable();
        if (userQueryParameters != null)
        {
            if (!string.IsNullOrWhiteSpace(userQueryParameters.Name))
            {
                query = query.Where(u => u.Name.Contains(userQueryParameters.Name));
            }
            if (userQueryParameters.IsVeteran.HasValue)
            {
                query = query.Where(u => u.IsVeteran == userQueryParameters.IsVeteran);
            }
            if (!string.IsNullOrWhiteSpace(userQueryParameters.Email))
            {
                query = query.Where(u => u.Email.Contains(userQueryParameters.Email));
            }
        }

        var result = await query.ToListAsync();

        return result;
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public Task Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
