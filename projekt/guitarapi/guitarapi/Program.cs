global using Microsoft.EntityFrameworkCore;
using guitarapi.Data;
using guitarapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGuitarService, GuitarService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<IStringsService, StringsService>();
builder.Services.AddScoped<IGuitarTypeService, GuitarTypeService>();
builder.Services.AddScoped<IGuitaristService, GuitaristService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
