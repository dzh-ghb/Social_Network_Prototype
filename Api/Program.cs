using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApiServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // в проде быть не должно
{
    await app.InitializeDatabaseAsync(); // наполнение тестовыми данными
}

app.UseApiServices();

app.Run();
