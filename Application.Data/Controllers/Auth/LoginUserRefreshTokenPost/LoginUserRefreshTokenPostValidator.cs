namespace Application.Data.Controllers.Auth.LoginUserPost;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserRefreshTokenPostValidator : AbstractValidator<LoginUserRefreshTokenPostRequest>
{
    public LoginUserRefreshTokenPostValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotNull().WithMessage("RefreshToken não pode ser null")
            .NotEmpty().WithMessage("RefreshToken não pode ser vazio");
    }
}
