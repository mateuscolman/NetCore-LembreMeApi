using LembreMeApi;
using LembreMeApi.Infra;
using LembreMeApi.Models;
using LembreMeApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["ConnectionStrings:MySql"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<AplicacaoContexto>(options =>
    options.UseMySql(connection, serverVersion));
builder.Services.AddMvc();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "\"Authorization: {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
});
builder.Services.AddRepository();
builder.Services.AddFactoryService();

var key = Encoding.ASCII.GetBytes(ConfigCompartilhada.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-1);
});


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
