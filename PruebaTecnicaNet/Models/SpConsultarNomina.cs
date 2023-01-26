using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Models
{
    public class SpConsultarNomina
    {
        [Key]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; } = null!;
        public int? evento { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Usuario { get; set; } = null!;
        public int? Val_nomina { get; set; }
    }
}
