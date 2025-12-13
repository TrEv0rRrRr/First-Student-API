using Cortex.Mediator.DependencyInjection;
using Cortex.Mediator.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using eb7414u20231b475.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7414u20231b475.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using eb7414u20231b475.API.Shared.Domain.Repositories;
using eb7414u20231b475.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7414u20231b475.API.Shared.Infrastructure.Mediator.Cortex.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
.AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()); });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
  if (builder.Environment.IsDevelopment())
    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
  else if (builder.Environment.IsProduction())
    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1",
      new OpenApiInfo
      {
        Title = "First Student.API",
        Version = "v1",
        Description = "First Student.API",
        License = new OpenApiLicense
        {
          Name = "Apache 2.0",
          Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
      });
});

// Dependency Injection

// Shared BC
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
      options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });

var app = builder.Build();
// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<AppDbContext>();

  context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();