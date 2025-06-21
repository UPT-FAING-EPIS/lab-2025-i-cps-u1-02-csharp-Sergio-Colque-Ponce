var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

/// <summary>
/// Representa un pronóstico del tiempo para una fecha específica.
/// </summary>
/// <param name="Date">La fecha del pronóstico.</param>
/// <param name="TemperatureC">La temperatura en grados Celsius.</param>
/// <param name="Summary">Un resumen descriptivo del clima (ej: "Soleado", "Lluvioso").</param>
/// <remarks>
/// Este record proporciona una representación inmutable de los datos del pronóstico del tiempo,
/// incluyendo conversión automática de temperatura de Celsius a Fahrenheit.
/// </remarks>
/// <example>
/// <code>
/// var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 25, "Soleado");
/// Console.WriteLine($"Temperatura: {forecast.TemperatureF}°F"); // Muestra la temperatura en Fahrenheit
/// </code>
/// </example>
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Obtiene la temperatura en grados Fahrenheit.
    /// </summary>
    /// <value>La temperatura convertida de Celsius a Fahrenheit.</value>
    /// <remarks>
    /// La conversión se realiza usando la fórmula: F = C / 0.5556 + 32
    /// </remarks>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
