using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.Entidades.Repositorios
{
    public class RepositorioEnMemoria : IRepositorio
    {
        private List<Genero> _generos;
        public RepositorioEnMemoria() 
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id = 1, Nombre = "Accion"},
                new Genero(){Id = 2, Nombre = "Terror"}

            };

            _guid = Guid.NewGuid(); // un guid es un string tipo 3216-ASDAEQF-7987-RYNTHN
        }
        public  Guid _guid;


        public List<Genero> ObtenerGeneros()
        {
            return _generos;
        }
        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(10);
            return _generos.FirstOrDefault(x => x.Id == Id);
        }
        public Guid ObtenerGuid()
        {
            return _guid;
        }

        public void CrearGenero (Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);
        }
    }
}