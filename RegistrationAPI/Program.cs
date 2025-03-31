using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RegistrationAPI.Endpoints;
using RegistrationAPI.Interfaces.Repositories.Users;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Interfaces.Services.OTP;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.MappingProfiles;
using RegistrationAPI.Middlewares;
using RegistrationAPI.Repository.Data;
using RegistrationAPI.Repository.Users;
using RegistrationAPI.Repository.OTP;
using RegistrationAPI.Services.OTP;
using RegistrationAPI.Services.User;
using RegistrationAPI.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(EndpointConfig.ConnectionStringName)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPinRepository, PinRepository>();
builder.Services.AddScoped<IOTPRepository, OTPRepository>();
builder.Services.AddScoped<IBiometricRepository, BiometricRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPinService, PinService>();
builder.Services.AddScoped<IOTPService, OTPService>();
builder.Services.AddScoped<IBiometricService, BiometricService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = EndpointConfig.SwaggerTitle, Version = "v1" });
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(EndpointConfig.SwaggerUrl, EndpointConfig.SwaggerTitle);
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
    OTPManagementEndpoints.MapEndpoints(appInstance);
    PinManagementEndpoints.MapEndpoints(appInstance);
    BiometricManagementEndpoints.MapEndpoints(appInstance);
}
