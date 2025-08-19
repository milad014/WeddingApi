
namespace Domain.Entities;

public class User
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Relation: Posts
    public List<Post> Posts { get; set; } = new();

    // Relation: Comments
    public List<Comment> Comments { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
