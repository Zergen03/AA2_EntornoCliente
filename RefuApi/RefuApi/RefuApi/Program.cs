using Microsoft.OpenApi.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RefuApi.Services;
using RefuApi.Data;

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


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
