using Application.UseCases;
using Domain.Repositories;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Dependency Injection

// Repositories
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

// UseCases
builder.Services.AddScoped<CreateTaskUseCase>();
builder.Services.AddScoped<ListTasksUseCase>();
builder.Services.AddScoped<CompleteTaskUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

app.Run();