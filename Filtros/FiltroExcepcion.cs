﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PeliculasApi.Filtros {
    public class FiltroExcepcion: ExceptionFilterAttribute {

        private readonly ILogger<FiltroExcepcion> _logger;

        public FiltroExcepcion(ILogger<FiltroExcepcion> logger) {
                _logger = logger;
        }

        public override void OnException(ExceptionContext context) {
            _logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}
