using LlmService;
using Microsoft.Extensions.AI;
using OllamaSharp;
 //IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "deepseek-r1:latest");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IChatClient>(new OllamaApiClient("http://localhost:11434/", "llama3.2"));
builder.Services.AddSingleton<IClientO, OllamaClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
