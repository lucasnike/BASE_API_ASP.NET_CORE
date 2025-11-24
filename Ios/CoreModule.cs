namespace Ioc;

using Application.Data.Controllers.WeatherForecast.WeatherForecastGetRequest;
using Application.Data.Extensions;
using FluentValidation;
using Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class CoreModule
{
    public static void AddCoreModules(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(Constants.DEFAULT_CONNECTION_STRING);
        var certificateA1Password = configuration.GetApplicationSecret("CertificateA1Password");
        var mediatorLicense = configuration[Constants.MEDIATR_LICENSE_KEY];

        services.AddDbContext<ApiContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddMediatR(conf =>
        {
            conf.LicenseKey = mediatorLicense;
            conf.RegisterServicesFromAssembly(Assembly.Load("Handlers"));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("Application.Data"));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
