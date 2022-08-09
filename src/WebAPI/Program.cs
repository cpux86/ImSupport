using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
}
    );

//builder.Services.AddAuthentication(config =>
//{
//    config.DefaultAuthenticateScheme =
//        JwtBearerDefaults.AuthenticationScheme;
//    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer("Bearer", options =>
//{
//    options.Authority = "https://localhost:5001/";
//    options.Audience = "web-api";
//    options.RequireHttpsMetadata = false;
//});
//builder.Services.AddAuthentication(config =>
//    {
//        config.DefaultAuthenticateScheme =
//            JwtBearerDefaults.AuthenticationScheme;
//        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer("Bearer", options =>
//    {
//        byte[] secretBytes = Encoding.UTF8.GetBytes(Constants.SecretKey);

//        var key = new SymmetricSecurityKey(secretBytes);

//        //options.Authority = "https://localhost:5001/";
//        //options.Audience = "web-api";
//        //options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidAudience = false,
//            ValidIssuer = Constants.Issuer,
//            ValidAudiences = Constants.Audience,
//            IssuerSigningKey = key
//        };
//    });

 builder.Services.AddAuthentication("OAuth")
        .AddJwtBearer("OAuth", config =>
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(Constants.SecretKey);

            var key = new SymmetricSecurityKey(secretBytes);

            config.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    if (context.Request.Query.ContainsKey("t"))
                    {
                        context.Token = context.Request.Query["t"];
                    }
                    return Task.CompletedTask;
                }
            };

            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = Constants.Issuer,
                ValidAudience = Constants.Audience,
                IssuerSigningKey = key
            };
        });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapDefaultControllerRoute();

app.Run();
