using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace pelisApi.Filtros
{
    public class FiltroExcepciones: ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroExcepciones> logger;

        public FiltroExcepciones(ILogger<FiltroExcepciones> logger)
        {
            this.logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}