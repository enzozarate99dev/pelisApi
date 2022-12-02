using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina {get; set;} = 1;
        private int recordsPagina = 10;
        private readonly int cantMaxRecordsPagina = 50;
    public int RecordsPorPagina
    {
        get
        {
            return recordsPagina;
        }
        set
        {
            recordsPagina = (value > cantMaxRecordsPagina) ? cantMaxRecordsPagina : value;
        }
    }
    
    }
}