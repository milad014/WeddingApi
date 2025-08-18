namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relation: Post
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    // Relation: User (Author of comment)
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
