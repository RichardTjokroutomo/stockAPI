using StockPortfolio.Services;
using StockPortfolio.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
//builder.Services.AddSingleton<MongoDBService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPortfolioService, MongoPortfolioService>();  // this is where we register the interface for DI


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
