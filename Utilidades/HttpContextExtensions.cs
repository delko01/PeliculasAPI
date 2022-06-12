using Microsoft.EntityFrameworkCore;

namespace PeliculasApi.Utilidades {
    public static class HttpContextExtensions {
        //Sirve para guardar la logica de las paginaciones (el nombre si no se por que puso asi) para todo donde se necesite contar registros (para eso es la <T>)
        //Le devuelve al front la cantidad de registros que existen para paginar

        public async static Task InsertParamPaginacionEnCabecera<T>(this HttpContext httpContext, IQueryable<T> queryable) { 
            if(httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double cantidad = await queryable.CountAsync();
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}
