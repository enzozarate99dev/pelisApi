using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using pelisApi;
using pelisApi.ApiBehavior;
using pelisApi.Filtros;
using pelisApi.Utilidades;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers(options =>
{
  options.Filters.Add(typeof(FiltroExcepciones));
  options.Filters.Add(typeof(ParsearBadRequest));
}).ConfigureApiBehaviorOptions(BehaviorBadRequest.Parsear);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddResponseCaching();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddCors(options =>
{
  var frontendURL = configuration.GetValue<string>("frontend_url");
  options.AddDefaultPolicy(builder =>
  {
    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
    .WithExposedHeaders(new string[] { "cantidadTotalRegistros"});
  });
});

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

var app = builder.Build();

	
// Add services to the container.
 

var logger = app.Services.GetService(typeof(ILogger<Program>)) as ILogger<Program>;
// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
