using Azure;

namespace Ioc;

using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Azure.Core;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;

public static class SecretsModule
{
    public async static Task RegisterCustomSecrets(this ConfigurationManager configuration)
    {
        var secretName = configuration[Constants.SECRET_NAME];
        var client = new AmazonSecretsManagerClient();
        var response = await GetSecretAsync(client, secretName);

        if (response is not null)
        {
            var secret = DecodeString(response);
            if (!string.IsNullOrEmpty(secret))
            {
                var secretObject = new
                {
                    Application = new
                    {
                        Secrets = JsonConvert.DeserializeObject(secret)
                    }
                };

                var secretJson = JsonConvert.SerializeObject(secretObject);

                var stream = new MemoryStream(Encoding.UTF8.GetBytes(secretJson));

                configuration.AddJsonStream(stream);
            }
            else
            {
                Console.WriteLine("No secret value was returned.");
            }
        }
    }

    public static async Task<GetSecretValueResponse> GetSecretAsync(IAmazonSecretsManager client, string secretName)
    {
        GetSecretValueRequest request = new GetSecretValueRequest()
        {
            SecretId = secretName,
            VersionStage = "AWSCURRENT",
        };

        GetSecretValueResponse response = null;

        try
        {
            response = await client.GetSecretValueAsync(request);
        }
        catch (AmazonSecretsManagerException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        return response;
    }

    public static string DecodeString(GetSecretValueResponse response)
    {
        // Decrypts secret using the associated AWS Key Management Service 
        // Customer Master Key (CMK.) Depending on whether the secret is a 
        // string or binary value, one of these fields will be populated. 
        if (response.SecretString is not null)
        {
            var secret = response.SecretString;
            return secret;
        }
        else if (response.SecretBinary is not null)
        {
            var memoryStream = response.SecretBinary;
            StreamReader reader = new StreamReader(memoryStream);
            string decodedBinarySecret =
            Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
            return decodedBinarySecret;
        }
        else
        {
            return string.Empty;
        }
    }
}
