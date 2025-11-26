namespace Infra.Services.Services.Implementations;

using Application.Data;
using Application.Data.Controllers.Auth.LoginUserPost;
using Application.Data.Exceptions.User;
using Application.Data.Extensions;
using Application.Data.Helpers;
using Azure.Core;
using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Infra.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthService(IConfiguration configuration, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<LoginUserPostResponse> AuthenticateAsync(LoginUserPostRequest request)
    {
        var user = await _userRepository.GetAsync(request.Username);

        var hashKey = _configuration.GetApplicationSecret(Constants.SECRET_USER_PASSWORD_HASH_KEY);
        string passwordHash = HashHelper.HMACSHA256(request.Password, hashKey);

        if (user.Password == passwordHash)
        {
            var token = GenerateToken(user);
            var refreshToken = await GenerateRefreshToken(user);

            return new LoginUserPostResponse
            {
                Username = user.Username,
                UserId = user.Id,
                AccessToken = token.token,
                AccessTokenExpiration = token.tokenDescriptor.Expires.Value,
                RefreshToken = refreshToken.refreshToken,
                RefreshTokenExpiration = refreshToken.expires
            };
        }

        throw new UserPasswordIncorrectException("Senha incorreta");
    }

    public async Task<LoginUserRefreshTokenPostResponse> AuthenticateRefreshTokenAsync(LoginUserRefreshTokenPostRequest request)
    {
        var user = await _userRepository.GetAsync(request.Username);
        var refreshToken = await _refreshTokenRepository.Get(request.RefreshToken);

        if (refreshToken is not null && refreshToken.IsValid() && refreshToken.UserId == user.Id && user is not null)
        {
            var token = GenerateToken(user);
            return new LoginUserRefreshTokenPostResponse
            {
                AccessToken = token.token,
                AccessTokenExpiration = token.tokenDescriptor.Expires.Value,
                UserId = user.Id,
                Username = user.Username
            };
        }

        throw new UserRefreshTokenInvalidException("Refreshtoken inválido ou expirado");
    }

    private async Task<(string refreshToken, DateTime expires)> GenerateRefreshToken(User user)
    {
        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenExpiration = DateTime.Now.AddDays(7);

        await _refreshTokenRepository.Insert(new RefreshToken
        {
            DueDate = refreshTokenExpiration,
            UserId = user.Id,
            Token = refreshToken,
        });

        return (refreshToken, refreshTokenExpiration);
    }

    private (string token, SecurityTokenDescriptor tokenDescriptor) GenerateToken(User user)
    {
        var audience = _configuration.GetApplicationSecret(Constants.SECRET_AUDIENCE);
        var issuer = _configuration.GetApplicationSecret(Constants.SECRET_ISSUER);

        var key = _configuration.GetApplicationSecret(Constants.SECRET_API_TOKEN_KEY);
        var keyBytes = Encoding.UTF8.GetBytes(key);

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

        foreach (var permission in user.Permissions)
        {
            if (!string.IsNullOrWhiteSpace(permission?.Name))
            {
                claims.Add(new Claim("permission", permission.Name));
            }
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
            Audience = audience,
            Issuer = issuer,
            Expires = DateTime.Now.AddDays(1),
            NotBefore = DateTime.Now
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwt = tokenHandler.CreateToken(tokenDescriptor);

        return (tokenHandler.WriteToken(jwt), tokenDescriptor);
    }
}
