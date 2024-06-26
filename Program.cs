using Backend.Automappers;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Backend.Services;
using Backend.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService,PeopleService>(); //Inyecta la implementacion de la interfaz

builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2Service");//Solo .NET 8 sirve para tener varias inmplementaciones y acceder mediante una key 

//Tipos de controlador
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");


builder.Services.AddScoped<IPostsService, PostsService>();

//Servicio Beer
builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

//HttpClient servicio jsonplaceholder (appsettings.json)
builder.Services.AddHttpClient/*Recibe las configuraciones de httpclient*/<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);//Configura la url del cliente para esta implementacion
});//Despues de la implementacion de IPostService

//Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();


//Entity Framework
//Conexion bd (appsettings.json)
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

//Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>(); //Inyeccion de validacion de insert en beers 
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>(); //Inyeccion de validacion de update en beers 

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile)); //Inyeccion de auto mapper

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
