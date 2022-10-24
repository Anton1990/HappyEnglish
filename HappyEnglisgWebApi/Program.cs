using HappyEnglisgWebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HappyEnglisgWebApi.Repositories;
using HappyEnglisgWebApi.Model;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings1.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBInteractor>();
builder.Services.AddDbContext<DBInteractor1>();
builder.Services.AddScoped<IGamerRepostory, GamerRepository>();





builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7088",
            ValidAudience = "https://localhost:7088",
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("superSecretKey@345"))
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.Map("/json", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["company"]}");
app.MapGet("/json", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["company"]}");

app.Run();
