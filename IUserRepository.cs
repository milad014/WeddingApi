using Domain.Entites;

namespace Application.Interfaces;


public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);

}
