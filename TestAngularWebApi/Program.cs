using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestAngularWebApi.TestAngularDB;
using TestAngularWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string sqlConnection = builder.Configuration.GetConnectionString("tzangDBconn");
builder.Services.AddDbContext<TestAngularDbContext>(options => options.UseSqlServer(sqlConnection));

builder.Services.AddTransient<FieldsValidator>();

builder.Services.AddCors();

builder.Services.AddLogging();

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

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
