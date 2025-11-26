namespace Application.Data.Controllers.Auth.LoginUserPost;

using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserPostResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiration { get; set; }

    public string Username { get; set; }
    public int UserId { get; set; }
}
