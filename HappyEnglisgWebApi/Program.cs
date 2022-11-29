using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HappyEnglisgWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using HappyEnglishWebApi.DAL;
using Serilog;
using Serilog.Events;
using HappyEnglishWebApi.Login;
using HappyEnglishWebApi.Repositories;
using HappyEnglisgWebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
                    .AddJsonFile("appsettings.json");
                   
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("GameDbConnect");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlite(connection));
builder.Services.AddScoped<IGamerRepostory, GamerRepository>();
builder.Services.AddScoped<IGenerateTokenService, GenerateTokenService>();
builder.Services.AddScoped<CustomFilterDI>();

//Logger
var path = builder.Configuration.GetConnectionString("FilePath");
builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .Enrich.FromLogContext()
            .WriteTo.File(path)
            .WriteTo.Console()
            .CreateLogger();
builder.Logging.AddSerilog(Log.Logger);

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


app.Run();
