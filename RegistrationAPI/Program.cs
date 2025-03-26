using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RegistrationAPI.Endpoints;
using RegistrationAPI.Endpoints.UserManagement;
using RegistrationAPI.Interfaces.Repositories;
using RegistrationAPI.Interfaces.Services;
using RegistrationAPI.MappingProfiles;
using RegistrationAPI.Middlewares;
using RegistrationAPI.Repository.Data;
using RegistrationAPI.Repository.Repositories;
using RegistrationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Registration API", Version = "v1" });
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registration API V1");
    c.RoutePrefix = "swagger";
});

RegisterEndpoints(app);

app.Run();

void RegisterEndpoints(WebApplication appInstance)
{
    UserEndpoints.MapEndpoints(appInstance);
    UserSearchEndpoints.MapEndpoints(appInstance);
    UserStatusEndpoints.MapEndpoints(appInstance);
    UserMigrationEndpoints.MapEndpoints(appInstance);
    UserBulkEndpoints.MapEndpoints(appInstance);
}