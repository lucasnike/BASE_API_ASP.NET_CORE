namespace Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;

using System;
using System.Collections.Generic;
using System.Text;

public class WeatherForecastGetResponse
{
    public IList<Domain.Entities.WeatherForecast> WeatherForecasts { get; set; } = new List<Domain.Entities.WeatherForecast>();
}
