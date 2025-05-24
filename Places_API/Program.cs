using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Places_API.Data;
using Places_API.Models;
using Places_API.Services.Auth;
using Places_API.Services.Place;
using Places_API.Services.Category;
using AutoMapper;
using Places_API.DTO;
using System.Text;
using SQLitePCL;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlacesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddSingleton<IMapper>(sp =>
    new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper()
);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey))
            throw new InvalidOperationException("JWT Key is not configured.");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

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