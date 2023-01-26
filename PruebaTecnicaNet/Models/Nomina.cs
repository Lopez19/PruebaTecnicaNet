using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Models
{
    public class Nomina
    {
        [Key]
        public int? Id_empleado { get; set; }
        public int? Cod_concepto { get; set; }
        public string? Desc_concepto { get; set; }
        public string? Documento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int? Val_nomina { get; set; }
        public int? Cantidad { get; set; }
    }
}
