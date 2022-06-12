using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Entidades {
    public class Actor {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public String Nombre { get; set; }
        public String Biografia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Foto { get; set; }
    }
}
