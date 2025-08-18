using Domain.Entities;

namespace Blog.Aplication.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> GetByIdAsync(int id);
        Task<List<Comment>> GetAllByPostIdAsync(int postId);
        Task AddAsync(Comment comment);
    }
}
