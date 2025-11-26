namespace Handlers.Auth;

using Application.Data;
using Application.Data.Controllers.Auth.LoginUserPost;
using Infra.Services.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class LoginUserRefreshTokenPostHandler : IRequestHandler<LoginUserRefreshTokenPostRequest, DefaultResponse<LoginUserRefreshTokenPostResponse>>
{
    private readonly IAuthService _authService;

    public LoginUserRefreshTokenPostHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<DefaultResponse<LoginUserRefreshTokenPostResponse>> Handle(LoginUserRefreshTokenPostRequest request, CancellationToken cancellationToken)
    {
        var resp = await _authService.AuthenticateRefreshTokenAsync(request);

        return new DefaultResponse<LoginUserRefreshTokenPostResponse>
        {
            Data = resp,
            Message = "Usuário autenticado"
        };
    }
}
