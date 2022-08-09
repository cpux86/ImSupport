using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(config =>
    {
        config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = "oidc";
    })
    //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect("oidc", config =>
    {
        config.Authority = "https://localhost:8001";
        config.ClientId = "client_id_mvc";
        config.ClientSecret = "client_secret_mvc";
        config.SaveTokens = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        config.ResponseType = "code";
        config.GetClaimsFromUserInfoEndpoint = true;
    });



builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();


//app.MapControllers();

app.MapControllerRoute(name: "Default",
    pattern: "{controller=Site}/{action=Index}/{id?}");

app.Run();
