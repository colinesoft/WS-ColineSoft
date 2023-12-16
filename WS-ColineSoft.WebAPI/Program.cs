using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Functions;
using WS_ColineSoft.WebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
