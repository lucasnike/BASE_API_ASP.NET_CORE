namespace Infra.Services.Services.Interfaces;

using Application.Data.Controllers.Auth.LoginUserPost;
using System;
using System.Collections.Generic;
using System.Text;

public interface IAuthService : IService
{
    Task<LoginUserPostResponse> AuthenticateAsync(LoginUserPostRequest request);
    Task<LoginUserRefreshTokenPostResponse> AuthenticateRefreshTokenAsync(LoginUserRefreshTokenPostRequest request);

}
