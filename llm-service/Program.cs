using Backend.BusinessLogic.ChatMessageEntityService;
using Backend.BusinessLogic.UserService;
using Backend.DataAccessLayer.repositories;
using LlmService;
using LlmService.BusinessLogic;
using LlmService.DataAccessLayer;
using LlmService.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
var ollamaUrl = builder.Configuration["Ollama:BaseUrl"]
    ?? throw new InvalidOperationException("Ollama:BaseUrl is missing.");

// Add services here
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddOpenApi();

//Add Repositoris here
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IChatMessageEnityRepository, ChatMessageEnityRepository>();
builder.Services.AddScoped<ChatMessageEntityService>();
builder.Services.AddSingleton<IChatClient>(new OllamaApiClient(new Uri(ollamaUrl), "llama3.2"));
builder.Services.AddSingleton<IClientO, OllamaClient>();


builder.Services.AddDbContext<DataAccessContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
