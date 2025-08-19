using Blog.Application.Interfaces;
using Domain.Entities;

namespace Blog.Application.Implement;
public class PostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public PostService(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllAsync();
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _postRepository.GetByIdAsync(id);
    }

    public async Task<Post> CreatePostAsync(string title, string content, int authorId)
    {
        var user = await _userRepository.GetByIdAsync(authorId);
        if (user == null)
            throw new Exception("Author not found");

        var post = new Post
        {
            Title = title,
            Content = content,
            AuthorId = authorId,
            CreatedAt = DateTime.UtcNow
        };

        await _postRepository.AddAsync(post);
        return post;
    }

    public async Task UpdatePostAsync(int id, string title, string content)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post == null)
            throw new Exception("Post not found");

        post.Title = title;
        post.Content = content;

        await _postRepository.UpdateAsync(post);
    }

    public async Task DeletePostAsync(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post == null)
            throw new Exception("Post not found");

        await _postRepository.DeleteAsync(post);
    }
}