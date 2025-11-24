namespace Ioc;

using Infra.Data.Repositories.Interfaces;
using Infra.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceModule
{
    public static void AddAppServices(this IServiceCollection services)
    {
        // SCOPED
        RegisterServicesByInterface(services, typeof(IService), "Infra.Services");
        RegisterServicesByInterface(services, typeof(IRepository), "Infra.Data");

        // SINGLETON

        // TRANSIENT
    }

    public static void RegisterServicesByInterface(IServiceCollection services, Type typeInterface, string assemblyName)
    {
        var myAssembly = Assembly.Load(assemblyName);

        var servicesToAdd = myAssembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeInterface) && t.IsClass);

        foreach (var service in servicesToAdd)
        {
            var firstInterface = service.GetInterfaces().FirstOrDefault();

            if (service != null && firstInterface != null)
            {
                services.Add(ServiceDescriptor.Scoped(firstInterface, service));
            }
        }
    }
}
