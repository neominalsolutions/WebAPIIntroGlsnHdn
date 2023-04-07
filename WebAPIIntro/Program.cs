using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIIntro.Data;
using WebAPIIntro.Controllers;
using WebAPIIntro.Services;

var builder = WebApplication.CreateBuilder(args); // uygulama creat edildi�i

builder.Services.AddControllers(); // controllerlar� s�rece dahil ettik.
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// e�er uygulama bir dbContext eklemek istersek AddDbContext dedi�imiz bir servis var. 
// dotnet run --environment=Production
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// nerede ILogger çağırırsam DbLogger instance al
// register işlemi
// bağımlılklar ve bağımlıkların instance alma şekilleri tek bir dosyadan yönetiliyor.
builder.Services.AddTransient<WebAPIIntro.Services.ILogger, DbLogger>();
builder.Services.AddTransient<ConsoleLogger>();


// IServiceCollection Interface üzerinden net core kendi IoC mekanizmasına sahip.

//builder.Services.AddDbContext<ApplicationContext>(opt =>
//{
//  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//builder.Services.AddDbContext<ApplicationContext>(opt =>
//{
//  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// uygulamaya eklenen servisler
// �al��ma an�nda uygulama add olarak ekleniyor.
// Microsoft.Extensions.DependencyInjection paket ile uygulama i�erisinde kullan�clacak olan servisleri uygulamaya register ediyoruz. daha sonra ilgili kod bloglar�ndan bu register etti�imiz servisleri DI dependecy injection ile consume (resolve) ediyoruz. (IoC Container) bu sayede teknoji altyap�lar� �evik bir �ekilde de�i�en bir mimari ile tek bir dosyadan t�m altyap�sal servisleri y�netiyoruz.

var app = builder.Build(); // �al��an uygulama instance ile uygulama request response pipeline yeni yeni middleware dedi�imiz ara yaz�l�mlar ekleyece�iz.


//app.Use(async (context, next) =>
//{

  
//  await next(context);

//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 

  app.UseSwagger(); // next()
  app.UseSwaggerUI(); // next()
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};



app.UseHttpsRedirection(); // next use middlewareler bir sonraki sat�rdaki ara yaz�l�ma s�reci devereder.




var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// /weatherforecast endpoint istek gelirse Minimal AP� y�ntemi
app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateTime.Now.AddDays(index),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast");


// uygulama i�erisinde y�nlendirme kurallar�n� uygula.
app.MapControllers();



// use middleware de�il run middleware oldu�u i�in response client d�ner. k�sa devre i�i bu noktada keser
app.Run();



internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
