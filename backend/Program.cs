using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Services;

 // Add this line to include the namespace for IVesselService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with MySQL

    
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // Replace with your MySQL version
    ));


// Add Swagger support
builder.Services.AddEndpointsApiExplorer();  // This is necessary for Swagger API exploration.
builder.Services.AddSwaggerGen(); 
 // This registers Swagger services.
builder.Services.AddScoped<IVesselService, VesselService>();
builder.Services.AddScoped<IManagementService, ManagementService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // URL of your React app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();  // This enables Swagger.
    app.UseSwaggerUI();  // This provides the Swagger UI for testing the API.
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers to endpoints
app.MapControllers();

app.Run();
