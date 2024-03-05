using Microsoft.OpenApi.Models;
using ObraPrima.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Obra Prima API",
        Version = "v1",
        Description = ""
    });
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });
});
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();
builder.AddRepositories();
builder.AddServices();
builder.Services.AddCors(x =>
{
    x.AddPolicy(name: "AllowSpecificOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:5120", "https://localhost:7176")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
    x.AddPolicy(name: "ObraPrima", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("https://app.obraprima.eng.br")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
}
    app.UseSwagger();
    app.UseSwaggerUI();

if (app.Environment.IsProduction())
{
    app.UseCors("ObraPrima");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapSwagger();

app.Run();