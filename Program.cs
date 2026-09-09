var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
.WithName("GetWeatherForecast");
//Hello endpoint
app.MapGet("/hello", () =>
{
    return "Hello from my first API";
});
//name endpoint
app.MapGet("/name", () =>
{
    return "My name is Giwa Toheeb";
});

//course
app.MapGet("/course", () =>
{
    return "I am learning ASP.NET core.";
});

//student
app.MapGet("/student", () =>
{
    return new
    {
        Name = "Giwa",
        Age = 26,
        Course = "ASP.NET core",
    };
});

//laptop
app.MapGet("/laptop", () =>
{
    return new[]
    {
        new
        {
            Brand = "Lenovo",
            Price = 15000,
            Year = 2025
        },
        new
        {
             Brand = "HP",
             Price = 15000,
             Year = 2020
        },
        new
        {
            Brand = "Dell",
            Price = 15000,
            Year = 2018
        }
    };
});

app.MapGet("/phone", () =>
{
    return new[]
    {
        new Phone
        {
        Brand = "Infinix",
        Price = 2000,
        ProductionYear = 2020
         },
         new Phone
        {
             Brand = "Tekno",
             Price = 3000,
             ProductionYear = 2024
          },
          new Phone
          {
            Brand = "Iphone",
            Price = 450343,
            ProductionYear = 2023
        }
    };
});

app.Run();

class Phone
{
    public string? Brand { get; set; }
    public int Price { get; set; }
    public int ProductionYear { get; set; }
}


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
