using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Webapi.DBOperations;
using Webapi.Middlewares;
using Webapi.Services;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// BookStoreDbContext'i projeye gösterdiğimiz kod parçası
// PRogram içerisinde servisleri kullanabilmek için eklememiz gerekli.
// Program.cs içerisinde servislere DbContext'in servis olarak eklenmesi
builder.Services.AddDbContext<BookStoreDbContext>(options=>options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
builder.Services.AddSingleton<ILoggerService,DbLogger>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Yazmış olduğumuz DataGenerator sınıfındaki Initialize metodunu porgram başlarken çalıştırdığımız kod parçası
// Uygulama ayağa kalktığından initial datanın in memory DB'ye yazılması için Program.cs içerisinde configurasyon yapılması
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExceptionMiddle();

app.UseAuthorization();

app.MapControllers();

app.Run();
