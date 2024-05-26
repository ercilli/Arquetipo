using Arquetipo.Pom.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddPaaS(configuration);
builder.Services.AddPOM(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UsePaas();

app.UsePOM();

//var middlewareRegistry = new MiddlewareRegistry();
//// Registro de middlewares base
//middlewareRegistry.RegisterBaseMiddleware(typeof(RequestInspectionMiddleware));
//middlewareRegistry.RegisterBaseMiddleware(typeof(RequestLoggerMiddleware));
//middlewareRegistry.RegisterBaseMiddleware(typeof(ResponseLoggerMiddleware));
//middlewareRegistry.RegisterBaseMiddleware(typeof(ResponseInspectionMiddleware));
//// ...otros middlewares base...

//middlewareRegistry.RegisterMiddlewareAtPosition(typeof(MiddlewarePom), 0);

//foreach (var middlewareType in middlewareRegistry.GetOrderedMiddlewareTypes())
//{
//    app.UseMiddleware(middlewareType);
//}

//app.UseMiddleware<RequestInspectionMiddleware>();

//app.UseMiddleware<RequestLoggerMiddleware>();

//app.UseMiddleware<ResponseLoggerMiddleware>();

//app.UseMiddleware<ResponseInspectionMiddleware>();

app.MapControllers();

app.Run();

