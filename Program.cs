using Microsoft.EntityFrameworkCore;
using PeliculasApi;
using PeliculasApi.APIComportamiento;
using PeliculasApi.Filtros;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(FiltroExcepcion));// filtro global para manejar excepciones
    options.Filters.Add(typeof(FiltroBadRequest));//Filtro global para los errores http mostrarlos como lista en el front
}).ConfigureApiBehaviorOptions(ComportamientoBadRequest.Parsear);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configuro CORS
var FrontOrigenes = "FrontEndURL";
builder.Services.AddCors(options=> {
    options.AddPolicy(FrontOrigenes,
                          frontEnd => {
                              frontEnd.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .WithExposedHeaders(new string[] { "cantidadTotalRegistros" }); // Muestra la cabecera de la clase HttpContextExtensions
                          });
});

//Servicio de dbcontex 
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));

//Servicio de automaper para relacionar DTO con las entidades  automaticamente
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(FrontOrigenes);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
