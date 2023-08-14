using Application.Presents;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using static Application.Presents.GetAllChildrenQuery;

var builder = WebApplication.CreateBuilder(args);

// Add db context
builder.Services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase(databaseName: "SantaClausDb"), ServiceLifetime.Singleton);

// Add services to the container.

builder.Services.AddControllers().
        AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.IncludeFields = true;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllChildrenQuery).Assembly));

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetService<DataContext>();
context.SeedDbContext();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(builder => builder
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        );

    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
