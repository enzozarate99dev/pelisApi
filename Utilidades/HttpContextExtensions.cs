using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pelisApi.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParamterosPaginacionCabecera<T>(this HttpContext httpContext,
        IQueryable<T> queryable) // <T> puede ser generos, peliculas, actores
        {
            //validacion
            if (httpContext == null) { throw new ArgumentException(nameof(httpContext));}

            //contar los registros
            double cantidad = await queryable.CountAsync();
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}