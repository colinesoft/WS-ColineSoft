using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Validators;
using WS_ColineSoft.Functions;
using WS_ColineSoft.WebAPI.AutoMapper;
using WS_ColineSoft.WebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<TesteDTO>, TesteValidator>();

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

//Injeção de dependência
builder.Services.ResolveDependenciesServices();
builder.Services.ResolveDependenciesRepositories();
//Validators
builder.Services.ResolveValidators();
//AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToViewModelConfig));
builder.Services.AddAutoMapper(typeof(ViewModelToDomainConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
