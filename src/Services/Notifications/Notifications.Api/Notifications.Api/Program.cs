using MediatR;
using Microsoft.OpenApi.Models;
using Notifications.Api;
using Notifications.Infraestructure;
using Notifications.Infraestructure.SendGrid;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var confbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

IConfiguration configuration = confbuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<ReApplyOptionalRouteParameterOperationFilter>();

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notifications.Api", Version = "v1" });

});

// Commands and query handlers
builder.Services.AddMediatR(Assembly.Load("Notifications.Application"));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddScoped<IMailService, SendGridService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.SwaggerEndpoint("v1/swagger.json", "Notifications.Api v1");
    config.DisplayRequestDuration();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
