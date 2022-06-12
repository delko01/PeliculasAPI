using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasApi.DTOs;
using PeliculasApi.Entidades;

namespace PeliculasApi.Controllers {
        [Route("api/actores")]
        [ApiController]
        public class ActoresController : ControllerBase {

            private readonly ApplicationDBContext _dbContext;
            private readonly IMapper _mapper;

            public ActoresController(ApplicationDBContext contex, IMapper mapper) {
                this._dbContext = contex;
                this._mapper = mapper;
            }

            [HttpPost]
            public async Task<ActionResult> Post([FromBody] ActorCreacionDTO actorCreacionDTO) {
                var actor = _mapper.Map<Actor>(actorCreacionDTO);
                _dbContext.Add(actor);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
        }
}
