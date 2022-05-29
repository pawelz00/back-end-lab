global using todo_api.Data;
global using Microsoft.EntityFrameworkCore;
global using todo_api.Models;
global using Microsoft.AspNetCore.Mvc;
using todo_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
