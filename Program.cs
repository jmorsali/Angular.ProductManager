global using Session12.ProductManager.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OnlineStoreContext>(opt => opt.UseInMemoryDatabase("OnlineStoreDB"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://localhost").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Policy1");

    using var scope = app.Services.CreateScope();
    OnlineStoreDataSeed.SeedData(scope.ServiceProvider.GetRequiredService<OnlineStoreContext>());
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
