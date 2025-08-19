using Blog.Application.Interfaces;
using Domain.Entities;

namespace Blog.Application.Implement;
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }


    public async Task<User> CreateUserAsync(string username, string email)
    {
        var user = new User(username, email)
        {
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
        return user;
    }
}