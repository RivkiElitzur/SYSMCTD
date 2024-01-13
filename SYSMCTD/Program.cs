using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SYSMCTD;
using SYSMCTD.Interfaces;
using SYSMCTD.Models;
using SYSMCTD.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("context")), ServiceLifetime.Singleton);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<Contacts>, ContactRepository>();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPoicy", builder => {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
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

app.UseCors("CorsPoicy");

app.Run();
