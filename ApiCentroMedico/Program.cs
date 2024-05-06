using ApiCentroMedico.Data;
using ApiCentroMedico.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NSwag.Generation.Processors.Security;
using NSwag;
using ApiCentroMedico.Helpers;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//A�adimos configuracion de keyvault.
builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});
SecretClient secretClient = builder.Services.BuildServiceProvider().GetService<SecretClient>();
KeyVaultSecret secretSqlAzure = await secretClient.GetSecretAsync("secretSqlAzure");
//KeyVaultSecret secretIssuer = await secretClient.GetSecretAsync("secretIssuer");
//KeyVaultSecret secretAudience = await secretClient.GetSecretAsync("secretAudience");
//KeyVaultSecret secretKey = await secretClient.GetSecretAsync("secretKey");

//Agregamos seguridad.
HelperActionServicesOAuth helper = new HelperActionServicesOAuth(secretClient);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticationSchema()).AddJwtBearer(helper.GetJwtBearerOptions());

//A�adimos repos y conecciones.
string connectionString = secretSqlAzure.Value;
builder.Services.AddTransient<RepositoryCentroMedico>();
builder.Services.AddDbContext<CentroMedicoContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// REGISTRAMOS SWAGGER COMO SERVICIO
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Api Centro Medico";
    document.Description = "Api Centro Medico.  Proyecto Personal 2024";
    // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
    // PERMITE A�ADIR EL TOKEN JWT A LA CABECERA.
    document.AddSecurity("JWT", Enumerable.Empty<string>(),
        new NSwag.OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Copia y pega el Token en el campo 'Value:' as�: Bearer {Token JWT}."
        }
    );
    document.OperationProcessors.Add(
    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});
//Nuevo ,lo comentamos por la docuemntacion del api
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Api Centro Medico"
//    });
//});

var app = builder.Build();

//Configuramos Swagger Web
app.UseOpenApi();
//app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Centro Medico v1");
    options.RoutePrefix = "";
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
//Agregamos seguridad
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
