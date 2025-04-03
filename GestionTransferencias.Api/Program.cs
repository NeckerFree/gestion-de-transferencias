using FluentValidation;
using GestionTransferencias.Api.Logger;
using GestionTransferencias.Api.Middleware;
using GestionTransferencias.Application;
using GestionTransferencias.Application.Behaviors;
using GestionTransferencias.Application.Billeteras.Validators;
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Mappings;
using GestionTransferencias.Persistence;
using GestionTransferencias.Persistence.Repositories;
using MediatR;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<IBilleteraRepository, BilleteraRepository>();
builder.Services.AddScoped<IHistorialMovimientoRepository, HistorialMovimientoRepository>();
builder.Services.AddAutoMapper(typeof(BilleteraProfile).Assembly);
builder.Services.AddAutoMapper(typeof(HistorialMovimientoProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<GetBilleteraByIdQueryValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Logging.ClearProviders(); // Clear default providers
builder.Logging.AddProvider(new FileLoggerProvider($"Logs/log-{DateTime.Now:yyyy-MM-dd}.txt"));

// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
