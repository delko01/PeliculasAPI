using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.DTOs {
    public class ActorCreacionDTO {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public String Nombre { get; set; }
        public String Biografia { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
