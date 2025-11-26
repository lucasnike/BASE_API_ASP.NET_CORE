using API;
using Application.Data.Controllers.Auth.LoginUserPost;
using Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;
using Application.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public class AuthController : DefaultController
    {
        [HttpPost("login/user")]
        public async Task<IActionResult> Post(LoginUserPostRequest req)
        {
            var response = await Mediator.Send(req);
            return Send(response);
        }

        [HttpPost("login/user/refresh")]
        public async Task<IActionResult> PostRefreshToken(LoginUserRefreshTokenPostRequest req)
        {
            var response = await Mediator.Send(req);
            return Send(response);
        }
    }
}
