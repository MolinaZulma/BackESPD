using BackESPD.Persistense;
using BackESPDWebAPI.Extensions;
using BackESPD.Application;
using BackESPD.Shared;
using BackESPD.SendEmail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Services
builder.Services.AddIOCApplicationLayer();
builder.Services.AddIOCPersintenceLayer(builder.Configuration);
builder.Services.AddApiVesionExtensions();
builder.Services.AddApiVesionExtensions();
builder.Services.AddIOCSendEmailLayer(builder.Configuration);
builder.Services.AddIOCApplicationLayerJWTDocumentation();
builder.Services.AddIOCSharedLayer();

//Configuración de CORS
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PolicyCors");
app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
