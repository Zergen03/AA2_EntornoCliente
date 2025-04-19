using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RefuApi.Data;
using RefuApi.Data.Intefaces;
using RefuApi.Services;
using RefuApi.Services.Interfaces;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RefuApi", Version = "v1" });
});

var connectionString = $"Server={Env.GetString("MYSQL_HOST")};" +
                       $"Port={Env.GetString("MYSQL_PORT")};" +
                       $"Database={Env.GetString("MYSQL_DB")};" +
                       $"Uid={Env.GetString("MYSQL_USER")};" +
                       $"Pwd={Env.GetString("MYSQL_PASSWORD")};";

builder.Services.AddDbContext<RefuApiContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
