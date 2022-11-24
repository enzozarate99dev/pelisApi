using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pelisApi.Entidades;
using pelisApi.Entidades.Repositorios;

namespace pelisApi.Controllers
{
    [Route("api/generos")] //endpoint para peticiones http
    [ApiController]
    public class GenerosController : ControllerBase //hereda metodos auxiliares de la clase controllerbase
    {
        private readonly IRepositorio repositorio;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        [HttpGet] //  api/generos
        [HttpGet("/listadogeneros")] //  /listadogeneros
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Mostrar los generos");
            return repositorio.ObtenerGeneros();
        }

        [HttpGet("guid")] //api/generos/guid
        public ActionResult<Guid> GetGuid()
        {
            return repositorio.ObtenerGuid();
        }

        [HttpGet("{Id:int}")] // api/generos/1
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string Nombre)
        {

            logger.LogDebug($"Obteniendo el genero por el id {Id}");

            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                logger.LogWarning($"No se encontro el generod de id: {Id}");
                return NotFound();
            }

            return genero;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}