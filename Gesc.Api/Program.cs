using MsCommun.Extensions;
using Gesc.Api.Extensions;
using Gesc.Api.GeneralExtensions;
using Gesc.Api.Datas;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuration Serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


Log.Information("GSCE Demmarre demarre ");
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));


builder.Services.AddSqlServerDbConfiguration<SchoolConfigDbContext>(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureControllerServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AjoutterCoucheDesProxies(builder.Configuration);
builder.Services.AddConfigurationMassTransitWithRabbitMQ(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.PrepPopulation(builder.Environment.IsProduction());

app.Run();

