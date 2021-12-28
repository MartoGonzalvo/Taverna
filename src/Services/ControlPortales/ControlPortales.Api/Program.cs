
using ControlPortales.Api;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Commands and query handlers
builder.Services.AddMediatR(Assembly.Load("ControlPortales.Application"));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

//Conexion a cosmosdb.
#if DEBUG
builder.Services.AddDbContext<CosmosDbContext>(options => options.UseCosmos(
                                                    "https://cosmosdb-rfidcleandesa.documents.azure.com:443",
                                                    "TCJII4KjKaywe9VOj9hJLjOCwA3a7NRseZaPfUfCICJtSuuQ9dKFv1RfRGENdQK5s4eosDwQ4ppzXol88WqdjQ==",
                                                    databaseName: "ControlPortalesDesa"));
#elif RELESASE
builder.Services.AddDbContext<CosmosDbContext>(options => options.UseCosmos(
                                                    "https://cosmosdb-rfidclean.documents.azure.com:443",
                                                    "KgKk9gxoA5LmarUnbGXAMcLYeUJMCJrmUJlvGmfteaK56SaKUQDhN3MZ4PJuTYsVE7MBTv8q6AwpgWyxX0qb4w==",
                                                    databaseName: "ControlPortales"));
#else
#endif


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