namespace Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;

using FluentValidation;

public class WeatherForecastGetValidator : AbstractValidator<WeatherForecastGetRequest>
{
    public WeatherForecastGetValidator()
    {
        RuleFor(x => x.Summary)
            .NotEmpty().WithMessage("Summary não pode ser vazio")
            .NotNull().WithMessage("Summary não pode ser nulo")
            .MinimumLength(3).WithMessage("Summary não pode ser vazio").WithMessage("Summary deve ter pelo menos 3 caracteres")
            .MaximumLength(100).WithMessage("Summary deve ter no máximo 100 caracteres");
    }
}
