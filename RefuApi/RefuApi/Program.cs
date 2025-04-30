using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RefuApi.Data;
using RefuApi.Data.Interfaces;
using RefuApi.Services;
using RefuApi.Services.Interfaces;
using RefuApi.Converters;
using Microsoft.AspNetCore.Authentication.JwtBearer;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
         options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
     });
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
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<IScheduleAssignmentRepository, ScheduleAssignmentRepository>();
builder.Services.AddScoped<IScheduleAssignmentService, ScheduleAssignmentService>();


//JWT Authentication
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Env.GetString("JWT_ISSUER"),
        ValidAudience = Env.GetString("JWT_AUDIENCE"),
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(Env.GetString("JWT_SECRET")))
    };

    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                message = "Unauthorized: token is missing or invalid."
            });
            return context.Response.WriteAsync(result);
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("VeteranOnly", policy => policy.RequireClaim("IsVeteran", "true"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
