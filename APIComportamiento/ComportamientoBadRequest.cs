using Microsoft.AspNetCore.Mvc;

namespace PeliculasApi.APIComportamiento {
    public static class ComportamientoBadRequest {
        public static void Parsear(ApiBehaviorOptions options) {
            options.InvalidModelStateResponseFactory = ActionContext => {
                var respuesta = new List<String>();
                foreach (var llave in ActionContext.ModelState.Keys) {
                    foreach (var error in ActionContext.ModelState[llave].Errors) {
                        respuesta.Add($"{llave}: {error.ErrorMessage}");
                    }
                }
                return new BadRequestObjectResult(respuesta);
            };
        }
    }
}
