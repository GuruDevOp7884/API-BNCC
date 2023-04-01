
using Microsoft.EntityFrameworkCore;
using Puc.BnccTeste.Infra.Data.Context;
using Puc.BnccTeste.Infra.Data.Interface;
using Puc.BnccTeste.Infra.Data.Repositorio;
using Puc.BnccTeste.Service.Interface;
using Puc.BnccTeste.Service.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI
builder.Services.AddScoped<IBnccMatematicaEfRepositorio, BnccMatematicaEfRepositorio>();
builder.Services.AddScoped<IBnccMatematicaEfService, BnccMatematicaEfService>();
builder.Services.AddScoped<IBnccLinguaPortuguesaEfService, BnccLinguaPortuguesaEfService>();
builder.Services.AddScoped<IBnccLinguaPortuguesaEfRepositorio, BnccLinguaPortuguesaEfRepositorio>();
#endregion

#region DB
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BnccTesteConnection"));
});
#endregion

#region Cors
builder.Services.AddCors();
#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
    c.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
