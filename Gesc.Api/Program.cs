using Gesc.Api.Extensions;
using Gesc.Api.GeneralExtensions;
using Gesc.Api.Datas;
using Gesc.Api.Extensions;
using MsCommun.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsProduction())
{
    builder.Services.AddSqlServerDbConfiguration<SchoolConfigDbContext>(builder.Configuration.GetConnectionString("ConfigSchoolConfigDb"));
}
else
{
    builder.Services.AddInMemoryDataBaseConfiguration<SchoolConfigDbContext>(builder.Configuration.GetConnectionString("ConfigSchoolConfigDb"));
}
builder.Services.AddSqlListeDbConfiguration<SchoolConfigDbContext>(builder.Configuration.GetConnectionString("ConfigSchoolConfigDb"));
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
