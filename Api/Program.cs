using Api.Exceptions;
using Application;
using Application.Behaviors;
using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
All Services 
*/
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers();

// MediatR Service 
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(IAssemplyMarker).Assembly));

// Fluent Validation Service
builder.Services.AddValidatorsFromAssembly(typeof(IAssemplyMarker).Assembly);

// Database And Sql Server Service
builder.Services.AddDbContext<AppDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Dependency Injection Services
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
builder.Services.AddScoped<IAppDbContext,AppDbContext>();


/*
The Middelwares start from Here
*/

var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
