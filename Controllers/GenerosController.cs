using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi.DTOs;
using PeliculasApi.Entidades;
using PeliculasApi.Utilidades;
using PeliculasApi.Validaciones;

namespace PeliculasApi.Controllers {

    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase {

        private readonly ILogger _logger;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public GenerosController(ILogger<GenerosController> logger, 
                                ApplicationDBContext context,
                                IMapper mapper) {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpGet("listado")]
        [PrimeraLetraMay]
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            _logger.LogInformation("Se muestran los generos");
            var queryable = _context.Generos.AsQueryable();
            await HttpContext.InsertParamPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return _mapper.Map<List<GeneroDTO>>(generos); //Hago el mapeo a GenerosDTO dados unos generos
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int id) {
            var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if(genero == null) {
                return NotFound();
            }

            return _mapper.Map<GeneroDTO>(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO) {
            var genero = _mapper.Map<Genero>(generoCreacionDTO); // Hago el mapeo a Genero dado un GeneroCreacionDTO
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO) {
            var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if(genero == null) return NotFound();

            genero = _mapper.Map(generoCreacionDTO, genero);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) { 
            

            try {
                var existe = await _context.Generos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (existe == null) return NotFound();

                _context.Remove(new Genero() { Id = id });
                await _context.SaveChangesAsync();
                return NoContent();
            } catch (Exception e) {
                var k = e.Message;
            }
            return NotFound();
        }

    }
}
    