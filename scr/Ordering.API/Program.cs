using MassTransit;
using Microsoft.Extensions.Configuration;
using Ordering.API.EventBusConsumer;
using Ordering.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var config = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<NotificationCheckoutConsumer>();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructureService(config);

builder.Services.AddMassTransit(confg =>
{
	confg.AddConsumer<Ordering.API.EventBusConsumer.NotificationCheckoutConsumer>();
	//Code Configuration RabbitMQ
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.Run();

