namespace Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime? DeletedAt { get; set; }
    public DateTime DueDate { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public bool IsValid()
    {
        return DeletedAt is null && DueDate > DateTime.Now;
    }
}
