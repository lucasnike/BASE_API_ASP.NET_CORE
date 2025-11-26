namespace Application.Data.Controllers.Auth.LoginUserPost;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

public class LoginUserPostValidator : AbstractValidator<LoginUserPostRequest>
{
    public LoginUserPostValidator()
    {
        RuleFor(x => x.Username)
            .NotNull().WithMessage("Username não pode ser null")
            .NotEmpty().WithMessage("Username não pode ser vazio")
            .MinimumLength(3).WithMessage("Username é muito curto");

        RuleFor(x => x.Password)
            .NotNull().WithMessage("Senha não pode ser nula")
            .NotEmpty().WithMessage("Senha não pode ser vazia")
            .MinimumLength(3).WithMessage("Senha é muito curta");
    }
}
