using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ObraPrima.Application.Services;
using ObraPrima.Application.Services.Contracts;
using ObraPrima.Domain;
using ObraPrima.Domain.Contracts.Repositories;
using ObraPrima.Infra.Data.Data;
using ObraPrima.Infra.Data.Repository;

namespace ObraPrima.Infra.IoC.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this IHostApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        
        Configuration.Secrets.JwtPrivateKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>(nameof(Configuration.Secrets.JwtPrivateKey)) ?? string.Empty;
    }
    public static void AddDatabase(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => 
            x.UseSqlServer(Configuration.Database.ConnectionString));
    }
    public static void AddJwtAuthentication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(x =>
            {
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(x =>
            {
                x.Cookie.Name = "X-Access-Token";
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["X-Access-Token"];
                        return Task.CompletedTask;
                    }
                };
            });
        builder.Services.AddAuthorization();
    }

    public static void AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>(); 
        builder.Services.AddScoped<ILeadService, LeadService>(); 
        builder.Services.AddScoped<IProposalService, ProposalService>(); 
        
    }
    public static void AddRepositories(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<ILeadRepository, LeadRepository>();
        builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
    }

}