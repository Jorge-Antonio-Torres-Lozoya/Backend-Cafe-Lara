using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Act17.Shared.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre no puede ser vació")]
        public string? Nombre_producto { get; set; }

        [Required(ErrorMessage = "El precio no puede ser vació no puede ser vació")]
        public int? Precio{ get; set; }

        [Required(ErrorMessage = "El stock no puede ser vació")]
        public int ? Stock { get; set; }
        [Required(ErrorMessage = "La fecha de elaboración no puede ser vacia no puede ser vació")]
        public DateTime Fecha_elaboracion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}
