using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Database;
using Serilog;
using Service.EventHandler.Infrastructure;
using Service.EventHandler.Profiles;
using Service.Queries.Infrastructure;
using System.Reflection;
using Web.Api.Filters;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuery();

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(AutoMapperEH));
builder.Services.AddMediatR(Assembly.Load("Service.EventHandler"));
builder.Services.AddDbContext<AplicationDBContext>(conex => conex.UseSqlServer(connectionString));
//builder.Services.AddDbContextPool<AplicationDBContext>(connectionString);

builder.Services.AddEventHandler();

string[] Origins = { "http://localhost:4200" };
string[] Methods = { "GET", "POST", "PUT", "DELETE" };

builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", builder => { builder.WithOrigins(Origins).WithMethods(Methods).AllowAnyHeader(); });
});

var seriLog = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(seriLog);

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Collection API",
        Description = "An ASP.NET Core web API for collections",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
