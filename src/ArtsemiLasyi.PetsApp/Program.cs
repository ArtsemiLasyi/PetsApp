using System.Reflection;
using ArtsemiLasyi.PetsApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
var configuration = builder.Configuration;

DiConfiguration.Configure(services);
DbConfiguration.Configure(services, configuration);
ValidationConfiguration.Configure(services);

services.AddAutoMapper(Assembly.GetExecutingAssembly());
services.AddEndpointsApiExplorer();
services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapControllers();
    }
);
app.Run();
