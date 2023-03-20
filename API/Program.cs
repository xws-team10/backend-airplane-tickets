using FlyMateLibrary.Core.Model;
using FlyMateLibrary.Core.Serivce;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<FlightsStoreDatabaseSettings>(
    builder.Configuration.GetSection("FlightsStoreDatabase"));

builder.Services.AddSingleton<FlightsService>();

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
