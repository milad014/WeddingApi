using Blog.Aplication.Implement;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("post/{postId}")]
    public async Task<ActionResult<List<Comment>>> GetByPostId(int postId)
    {
        return Ok(await _commentService.GetCommentsByPostIdAsync(postId));
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> Add([FromBody] AddCommentRequest request)
    {
        var comment = await _commentService.AddCommentAsync(request.PostId, request.Author, request.Text);
        return CreatedAtAction(nameof(GetByPostId), new { postId = request.PostId }, comment);
    }
}

public record AddCommentRequest(int PostId, string Author, string Text);