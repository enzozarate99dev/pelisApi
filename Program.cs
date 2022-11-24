using pelisApi.Entidades.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorio, RepositorioEnMemoria>(); //esto antes de .net6 se hacia en el archivo Startup

var app = builder.Build();

//var logger = app.Services.GetService(typeof(ILogger<Startup>)) as ILogger<Startup>;

// Configure the HTTP request pipeline.
// app.Use(async (context, next) =>
// {
// using (var swapStream = new MemoryStream())
// {
//     var respuestaOriginal = context.Response.Body;
//     context.Response.Body = swapStream;

//     await next.Invoke(); //para continuar la ejecucion del pipeline

//     swapStream.Seek(0, SeekOrigin.Begin);
//     string respuesta = new StreamReader(swapStream).ReadToEnd();
//     swapStream.Seek(0, SeekOrigin.Begin);

//     await swapStream.CopyToAsync(respuestaOriginal);
//     context.Response.Body = respuestaOriginal;

  //  logger.LogInformation(respuesta);
// }
// });

// app.Map("/mapa1", app => {
//     app.Run(async context => {
//         await context.Response.WriteAsync("Interceptando el pipeline");
//     });
// });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
