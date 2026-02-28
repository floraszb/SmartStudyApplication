using Microsoft.EntityFrameworkCore;
using SmartStudy.Infrastructure.Data;
using SmartStudy.Application.Interfaces;
using SmartStudy.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration["OpenAIKey"] = 
    Environment.GetEnvironmentVariable("OPENAI_API_KEY");

// Add PostgreSQL DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure CORS to allow frontend requests
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IAiService, OpenAiService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(); // apply CORS middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();