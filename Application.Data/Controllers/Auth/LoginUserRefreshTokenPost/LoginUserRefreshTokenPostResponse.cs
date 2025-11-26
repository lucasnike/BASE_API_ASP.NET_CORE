namespace Application.Data.Controllers.Auth.LoginUserPost;

using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserRefreshTokenPostResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpiration { get; set; }

    public string Username { get; set; } = string.Empty;
    public int UserId { get; set; }
}
