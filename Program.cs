using RapidApi_HotelAndTravel.Interfaces.BestHotel;
using RapidApi_HotelAndTravel.Interfaces.Travel;
using RapidApi_HotelAndTravel.Logic.BestHotel;
using RapidApi_HotelAndTravel.Logic.Travel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBestHotelLogic, BestHotelLogic>();
builder.Services.AddScoped<ITravel, Travel>();

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
