using RefuApi.Models;

namespace RefuApi.Data.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll(UserQueryParameters? userQueryParameters);
    Task<User?> GetById(int id);
    Task Add(User user);
    Task Update(User user);
    Task Delete(User user);
    Task SaveChangesAsync();
}