namespace Domain.Entities;


public class User
{
    public User()
    {
        Username = string.Empty;
        Password = string.Empty;
    }

    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted => DeletedAt.HasValue;

    public IList<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public IList<Permission> Permissions { get; set; } = new List<Permission>();
}
