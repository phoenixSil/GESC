using Gesc.Api.Extensions;
using Gesc.Api.GeneralExtensions;
using Gesc.Api.Datas;
using Serilog;
using MsCommun.Extensions;

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

//Add services to the container.
if(builder.Environment.IsProduction()){
    builder.Services.AddSqlServerDbConfiguration<SchoolConfigDbContext>(builder.Configuration.GetConnectionString("appConnString"));
}
else {
    builder.Services.AddInMemoryDataBaseConfiguration<SchoolConfigDbContext>("InMem");
}

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureControllerServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AjoutterCoucheDesProxies(builder.Configuration);

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

app.Run();
