using API;
using Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;
using Application.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public class WeatherForecastController : DefaultController
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new WeatherForecastGetRequest());
            return Send(response);
        }
    }
}
