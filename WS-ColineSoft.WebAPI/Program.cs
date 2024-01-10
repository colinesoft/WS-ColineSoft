using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using System.Text.Json.Serialization;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Functions;
using WS_ColineSoft.WebAPI.AutoMapper;
using WS_ColineSoft.WebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation()
    .AddJsonOptions(opt => {
        //Resolvendo problema de object cycle (OBJECT CYCLE)
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region SWAGGER Config
builder.Services.AddSwaggerGen(e =>
{
    e.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    e.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
            new List<string>()
        }
    });
});
#endregion

#region DBCONTEXT
//Configuração do Banco de dados para o DbContext
builder.Services.AddDbContext<ColineSoftContext>(option =>
{
    string database = builder.Configuration["ConnectionStrings:Database"] ?? "";
    string user = builder.Configuration["ConnectionStrings:User"] ?? "";
    string password = builder.Configuration["ConnectionStrings:Password"] ?? "";
    int chaveCript = int.Parse(builder.Configuration["ConnectionStrings:ChaveCripto"] ?? "0");
    string strConnection = string.Format(builder.Configuration["ConnectionStrings:StrConnection"] ?? "", database, user, password.Cripto(chaveCript, CriptoValues.Uncripto));

    option.UseSqlServer(strConnection);
});
#endregion

#region INJEÇÃO DE DEPENDÊNCIA
//Injeção de dependência
builder.Services.ResolveDependenciesServices();
builder.Services.ResolveDependenciesRepositories();
#endregion

#region VALIDATORS
//Validators
builder.Services.ResolveValidators();
#endregion

#region AUTO MAPPER
//AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToViewModelConfig));
builder.Services.AddAutoMapper(typeof(ViewModelToDomainConfig));
#endregion

#region JWT
//Authentication JWT
//Antenção que o Swagger tb foi alterado para permitir inclusão do token nas requisições
builder.Services.AddAuthentication(e =>
{
    //Foi necessário instalar um pacote JwtBearer
    e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(e =>
{
    e.RequireHttpsMetadata = false;
    e.SaveToken = true;
    e.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

#region SERILOG
//SERILOG
//Configurações necessárias para iniciarlizar o SERILOG
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/arquivo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders(); //Necesário limpar o logger padrão
builder.Logging.AddSerilog(logger);
#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(e => {
        e.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
