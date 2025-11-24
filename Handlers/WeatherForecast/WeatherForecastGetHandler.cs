namespace Handlers.WeatherForecast;

using Application.Data;
using Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;
using Domain.Entities;
using Infra.Services.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class WeatherForecastGetHandler : IRequestHandler<WeatherForecastGetRequest, DefaultResponse<WeatherForecastGetResponse>>
{

    private readonly ILogger<WeatherForecastGetHandler> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastGetHandler(ILogger<WeatherForecastGetHandler> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    Task<DefaultResponse<WeatherForecastGetResponse>> IRequestHandler<WeatherForecastGetRequest, DefaultResponse<WeatherForecastGetResponse>>.Handle(WeatherForecastGetRequest request, CancellationToken cancellationToken)
    {
        var result = _weatherForecastService.GetRandomWeatherForecast();
        _logger.LogWarning("PREVISÕES DO TEMPO BUSCADAS PESO SERVIÇO");

        var test = new DefaultResponse<WeatherForecastGetResponse>
        {
            Data = new WeatherForecastGetResponse
            {
                WeatherForecasts = result.ToList()
            }
        };

        return Task.FromResult(test);
    }
}
