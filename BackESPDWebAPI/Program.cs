using BackESPD.Persistense;
using BackESPDWebAPI.Extensions;
using BackESPD.Application;
; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services
builder.Services.AddIOCApplicationLayer();
builder.Services.AddIOCPersintenceLayer(builder.Configuration);
builder.Services.AddApiVesionExtensions();
builder.Services.AddApiVesionExtensions();

//Configuración de CORS
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

/*
builder.Services.AddIOCApplicationLayerJWTDocumentation();
builder.Services.AddIOCApplicationLayer();
builder.Services.AddIOCPersintenceLayer(builder.Configuration);
builder.Services.AddIOCSendEmailLayer(builder.Configuration);
builder.Services.AddIOCSharedLayer();
builder.Services.AddApiVesionExtensions();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PolicyCors");
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
