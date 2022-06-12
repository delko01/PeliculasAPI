using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PeliculasApi.Filtros {
    public class FiltroBadRequest : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext context) {
            var castResult = context.Result as IStatusCodeActionResult;
            if (castResult == null) {
                return;
            }
            var codigoStatus = (context.Result as IStatusCodeActionResult).StatusCode;
            if (codigoStatus == 400) {
                var respuesta = new List<string>();
                var resultadoActual = context.Result as BadRequestObjectResult;
                if (resultadoActual.Value is string) {
                    respuesta.Add(resultadoActual.Value.ToString());
                }
                else {
                    foreach (var llave in context.ModelState.Keys) {
                        foreach (var error in context.ModelState[llave].Errors) {
                            respuesta.Add($"{llave}: {error.ErrorMessage}");
                        }
                    }
                }
                context.Result = new BadRequestObjectResult(respuesta);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            var castResult = context.Result as IStatusCodeActionResult;
            if (castResult == null) {
                return;
            }
            var codigoStatus = (context.Result as IStatusCodeActionResult).StatusCode;
            if (codigoStatus == 400) {
                var respuesta = new List<string>();
                var resultadoActual = context.Result as BadRequestObjectResult;
                if (resultadoActual.Value is string) {
                    respuesta.Add(resultadoActual.Value.ToString());
                }
                else {
                    foreach (var llave in context.ModelState.Keys) {
                        foreach (var error in context.ModelState[llave].Errors) {
                            respuesta.Add($"{llave}: {error.ErrorMessage}");
                        }
                    }
                }
                context.Result = new BadRequestObjectResult(respuesta);
            }
        }
    }
}
