namespace Domain.Entities;

public class Post
{
    public int Id { get; set; }             
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relation: Author
    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;

    // Relation: Comments
    public List<Comment> Comments { get; set; } = new();
}