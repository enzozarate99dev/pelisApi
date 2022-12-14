using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pelisApi.DTOs;
using pelisApi.Entidades;
using pelisApi.Utilidades;

namespace pelisApi.Controllers
{
    [ApiController]
    [Route("api/cines")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class CinesController : ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(AplicationDbContext context,
        IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] //  api/cines
        public async Task<ActionResult<List<CineDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable =  context.Cines.AsQueryable();
            await HttpContext.InsertarParamterosPaginacionCabecera(queryable);
            var cines = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<CineDTO>>(queryable);
        }
         [HttpGet("{Id:int}")]
        public async Task<ActionResult<CineDTO>> Get(int Id)
        {

            var cine = await context.Cines.FirstOrDefaultAsync(x => x.Id == Id );
            if (cine == null)
            {
                return NotFound();
            }
            return mapper.Map<CineDTO>(cine);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id,[FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = await context.Cines.FirstOrDefaultAsync(x => x.Id == Id);
            if(cine == null)
            {
                return NotFound();

            }
            cine = mapper.Map(cineCreacionDTO, cine);
            await context.SaveChangesAsync();
            return NoContent();
        }
          [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Cines.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Cine() {Id = id});
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}