namespace Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

public class Permission
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IList<User> Users { get; set; } = new List<User>();
}
