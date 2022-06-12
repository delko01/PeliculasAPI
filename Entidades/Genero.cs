using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Entidades {
    public class Genero {

        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        public String Nombre { get; set; }
    }
}
