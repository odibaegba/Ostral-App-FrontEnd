using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Ostral.WEB.Extensions
{
    public static class AuthenticationConfiguration
    {
        public static void AddAuthenticationExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(v =>
                {
                    v.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = configuration.GetSection("Jwt:Issuer").Value != null,
                        ValidateLifetime = true,
                        ValidateAudience = configuration.GetSection("Jwt:Audience").Value != null,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.GetSection("Jwt:Issuer").Value ?? null,
                        ValidAudience = configuration.GetSection("Jwt:Audience").Value ?? null,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Token") ?? string.Empty))
                    };
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/auth/login";
                    options.LogoutPath = "/auth/logout";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Forbidden/";
                    options.ForwardAuthenticate = CookieAuthenticationDefaults.AuthenticationScheme;
                });
        }
    }
}
