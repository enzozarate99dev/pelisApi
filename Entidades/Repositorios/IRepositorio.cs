using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.Entidades.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObtenerGeneros();
        Task<Genero> ObtenerPorId(int Id);
        Guid ObtenerGuid();
        void CrearGenero (Genero genero);
    }
}