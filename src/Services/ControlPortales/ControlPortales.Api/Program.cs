
using ControlPortales.Api;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlPortales.Api", Version = "v1" });
});

// Commands and query handlers
builder.Services.AddMediatR(Assembly.Load("ControlPortales.Application"));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

//Conexion a cosmosdb.
builder.Services.AddDbContext<CosmosDbContext>(options => options.UseCosmos(
                                                    "https://cosmosdb-rfidclean.documents.azure.com:443",
                                                    "KgKk9gxoA5LmarUnbGXAMcLYeUJMCJrmUJlvGmfteaK56SaKUQDhN3MZ4PJuTYsVE7MBTv8q6AwpgWyxX0qb4w==",
                                                    databaseName: "ControlPortales"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("v1/swagger.json", "ControlPortales.Api v1");
        config.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();