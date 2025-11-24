namespace Infra.Services.Services.Implementations;

using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Infra.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ISummaryRepository _summaryRepository;

    public WeatherForecastService(ISummaryRepository summaryRepository)
    {
        _summaryRepository = summaryRepository;
    }

    public IEnumerable<WeatherForecast> GetRandomWeatherForecast()
    {
        var summaries = _summaryRepository.Get().ToList();

        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Count())]
        }).ToList();

        return result;
    }
}
