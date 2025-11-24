namespace Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;

using MediatR;

public class WeatherForecastGetRequest : IRequest<DefaultResponse<WeatherForecastGetResponse>>
{
    public string Summary { get; set; } = "";
}
