using AutoMapper;
using PeliculasApi.DTOs;
using PeliculasApi.Entidades;

namespace PeliculasApi.Utilidades {
    public class AutoMapperProfiles: Profile {

        public AutoMapperProfiles() {

            CreateMap<Genero, GeneroDTO>().ReverseMap();// De Genero a GeneroDTO y viceverza
            CreateMap<GeneroCreacionDTO, Genero>(); // De generoCreacionDTO a Genero

            CreateMap<Actor, ActorDTO>().ReverseMap();// De Actor a ActorDTO y viceverza
            CreateMap<ActorCreacionDTO, Actor>() // De ActorCreacionDTO a Actor (ignoro la foto porque se maneja de forma diferente)
                .ForMember(x => x.Foto, options => options.Ignore());
        }
    }
}
