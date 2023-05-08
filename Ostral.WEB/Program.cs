using Ostral.WEB.Middlewares;
using Ostral.Core.Utilities;
using Ostral.WEB.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling
               = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAutoMapper(typeof(OstralProfile));
builder.Services.AddAppSettingsConfig(builder.Configuration, builder.Environment);
builder.Services.AddAuthenticationExtension(builder.Configuration);
builder.Services.AddAuthorizationExtension();
builder.Services.AddServicesExtension(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddLogging();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Lax,
});
app.Use(async (context, next) =>
{
    var token = context.User?.Claims!.FirstOrDefault(c => c.Type == "jwt")?.Value;
    if (!string.IsNullOrWhiteSpace(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
