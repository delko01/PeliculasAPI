using Microsoft.EntityFrameworkCore;
using PeliculasApi.Entidades;

namespace PeliculasApi {
    public class ApplicationDBContext: DbContext {

        public ApplicationDBContext(DbContextOptions options): base(options) { 
        
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
