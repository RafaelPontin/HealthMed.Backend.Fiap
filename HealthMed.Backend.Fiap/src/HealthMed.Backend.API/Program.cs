using HealthMed.Backend.API.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiConfiguration(builder.Configuration);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseApiConfiguration();

app.Run();
