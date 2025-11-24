namespace Infra.Services.Services.Interfaces;

using Domain.Entities;

public interface IWeatherForecastService : IService
{
    IEnumerable<WeatherForecast> GetRandomWeatherForecast();
}
