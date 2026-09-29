using LlmService;
using LlmService.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
//IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "deepseek-r1:latest");
var builder = WebApplication.CreateBuilder(args);
var ollamaUrl = builder.Configuration["Ollama:BaseUrl"]
    ?? throw new InvalidOperationException("Ollama:BaseUrl is missing.");
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//when deplyng the container on azure, change route to that 
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
