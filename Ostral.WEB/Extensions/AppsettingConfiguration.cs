using Ostral.ConfigOptions;

namespace Ostral.WEB.Extensions;

public static class AppsettingConfiguration
{
    
    public static void AddAppSettingsConfig(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
    {
        var jwt = new Jwt();
        var apiSettings = new ApiSettings();

        if (env.IsProduction())
        {
            jwt.Token = Environment.GetEnvironmentVariable("JwtToken") ?? string.Empty;
            jwt.Issuer = Environment.GetEnvironmentVariable("JwtIssuer") ?? string.Empty;
            jwt.Audience = Environment.GetEnvironmentVariable("JwtAudience") ?? string.Empty;
            jwt.LifeTime = double.Parse(Environment.GetEnvironmentVariable("JwtLifeTime") ?? "3600");

            apiSettings.BaseUrl = Environment.GetEnvironmentVariable("ApiUrl");
        }
        else
        {
            config.Bind(nameof(jwt), jwt);
            config.Bind(nameof(apiSettings), apiSettings);
        }
        
        services.AddSingleton(jwt);
        services.AddSingleton(apiSettings);
    } 
}