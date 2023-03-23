using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;
using FlyMateAPI.Core.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<FlightsStoreDatabaseSettings>(
    builder.Configuration.GetSection("FlightsStoreDatabase"));

builder.Services.AddSingleton<FlightsService>();
builder.Services.AddSingleton<FlightsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
