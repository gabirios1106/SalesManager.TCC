using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SalesManager.API.Data;
using SalesManager.API.Interfaces;
using SalesManager.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SalesManagerContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("SQLiteConnection")
        )
    );

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program));

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
