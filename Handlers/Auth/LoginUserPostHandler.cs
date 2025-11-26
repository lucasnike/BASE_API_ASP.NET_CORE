namespace Handlers.Auth;

using Application.Data;
using Application.Data.Controllers.Auth.LoginUserPost;
using Infra.Services.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class LoginUserPostHandler : IRequestHandler<LoginUserPostRequest, DefaultResponse<LoginUserPostResponse>>
{
    private readonly IAuthService _authService;

    public LoginUserPostHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<DefaultResponse<LoginUserPostResponse>> Handle(LoginUserPostRequest request, CancellationToken cancellationToken)
    {
        var resp = await _authService.AuthenticateAsync(request);

        return new DefaultResponse<LoginUserPostResponse>
        {
            Data = resp,
            Message = "Usuário autenticado"
        };
    }
}
