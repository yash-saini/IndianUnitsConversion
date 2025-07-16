using ConversionAPI.Data;
using ConversionAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConversionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<LandConversionService>();
builder.Services.AddSingleton<WeightConversionService>();
builder.Services.AddSingleton<GoldPriceConversionService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<CurrencyConversionService>();
builder.Services.AddScoped<ConversionHistoryService>();

// Add this before building the app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin",
        builder => builder
            .WithOrigins("https://localhost:7106/")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazorOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
