using Arquetipo.Pom.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddPaaS(configuration);
builder.Services.AddPOM(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UsePaas();

app.UsePOM();

app.MapControllers();

app.Run();
