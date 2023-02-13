using JobAssistant.Domain.Services;
using JobAssistant.Extensions;
using JobAssistant.QueryExecutors.GetCosts;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.ExampleFilters();
});

builder.Services.AddTransient<GetCostsQuery>();
builder.Services.AddTransient<CostCalculator>();
builder.Services.AddTransient<ICostApplier, MarginApplier>();
builder.Services.AddTransient<ICostAdjuster, TaxAdjuster>();
builder.Services.AddSwaggerExamplesFromAssemblyOf(typeof(GetCostsQueryRequestDtoExample));


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
