using Core.APIAbank.Interfaces;
using Infrastructure.APIAbank.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System;
using Core.APIAbank.Repository;
using APIAbank;
using Microsoft.AspNetCore.Mvc;
using APIAbank.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<JwtService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbConnection>(db => new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=pruebaAbankBD;Integrated Security=True;Encrypt=False"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "mi_api",  // Debe coincidir con el emisor del token
            ValidAudience = "mi_cliente", // Debe coincidir con la audiencia del token
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi_clave_secreta_1234567890")) // Clave secreta para verificar la firma
        };
});
var app = builder.Build();


// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
public class Usuariotoken
{
    public string Telefono { get; set; }
    public string Contrasena { get; set; }
}