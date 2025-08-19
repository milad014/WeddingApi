using Blog.Application.Interfaces;
using Domain.Entities;

namespace Blog.Application.Implement;

public class CommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentService(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }
    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _commentRepository.GetAllByPostIdAsync(postId);
    }

    public async Task<Comment> AddCommentAsync(int postId, string author, string text)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null)
            throw new Exception("Post not found");

        var comment = new Comment
        {
            Author = author,
            Text = text,
            PostId = postId,
            CreatedAt = DateTime.UtcNow
        };

        await _commentRepository.AddAsync(comment);
        return comment;
    }
}