using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Data.Extensions;

public static class ApplicationConfigurationExtension
{

    public static string GetApplicationSecret(this IConfiguration configuration, string secretName)
    {
        var secret = configuration[$"{Constants.SECRET_DEFAULT_PATH}:{secretName}"];

        return secret;
    }

    public static T GetApplicationSecret<T>(this IConfiguration configuration, string secretName)
    {
        var secret = configuration[$"{Constants.SECRET_DEFAULT_PATH}:{secretName}"];
        var ret = JsonConvert.DeserializeObject<T>(secret);

        return ret;
    }
}