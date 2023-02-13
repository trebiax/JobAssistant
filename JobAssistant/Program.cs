using FluentAssertions.Common;
using JobAssistant.Domain.Services;
using JobAssistant.QueryExecutors.GetCosts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GetCostsQuery>();
builder.Services.AddTransient<CostCalculator>();
builder.Services.AddTransient<ICostApplier, MarginApplier>();
builder.Services.AddTransient<ICostAdjuster, TaxAdjuster>();


builder.Services.AddOptions<TaxOptions>()
                .Bind(builder.Configuration.GetSection(nameof(TaxOptions)));

builder.Services.AddOptions<MarginOptions>()
                .Bind(builder.Configuration.GetSection(nameof(MarginOptions)))
                .ValidateDataAnnotations();

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
