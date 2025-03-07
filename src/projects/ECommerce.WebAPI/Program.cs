using ECommerce.Application;
using ECommerce.Persistence;
using ECommerce.Infrastructure;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Security;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Infrastructure.CloudinaryServices;
using Core.ElasticSearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6381");
builder.Services.AddApplicationServiceDependencies();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSecurityServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CloudinaryService>();
builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddElasticSearch(builder.Configuration);

const string tokenOptionsConfigurationName = "TokenOptions";
TokenOptions tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationName).Get<TokenOptions>()
                            ?? throw new InvalidOperationException(
                                $"{tokenOptionsConfigurationName} section bulunamadı");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    }
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.ConfigureCustomExceptionMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication(); //kimlik doğrulama
app.UseAuthorization(); //yetkilendirme

app.MapControllers();

app.Run();
