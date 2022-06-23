using System.Net;
using Microsoft.EntityFrameworkCore;
using SmartPlant.API.DbContext;
using SmartPlant.API.Services;
using uPLibrary.Networking.M2Mqtt;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlantContext>(dbContextOptions => dbContextOptions.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    new MariaDbServerVersion(new Version())));

builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddSingleton<PlantMqttClient, PlantMqttClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure MQTT
var serviceScope = app.Services.CreateScope();
var services = serviceScope.ServiceProvider;
var client = services.GetRequiredService<PlantMqttClient>();
client.Connect();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();