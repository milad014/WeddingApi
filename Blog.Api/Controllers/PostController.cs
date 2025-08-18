using Blog.Aplication.Implement;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PostController : ControllerBase
{
    private readonly PostService? _postService;
    public PostController(PostService postService) { _postService = postService; }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAll()
    {
        return Ok(value: await _postService.GetAllPostsAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetById(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> Create([FromBody] CreatePostRequest request)
    {
        var post = await _postService.CreatePostAsync(request.Title, request.Content, request.AuthorId);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePostRequest request)
    {
        await _postService.UpdatePostAsync(id, request.Title, request.Content);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }
}

public record CreatePostRequest(string Title, string Content, int AuthorId);
public record UpdatePostRequest(string Title, string Content);
