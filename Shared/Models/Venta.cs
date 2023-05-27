using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Act17.Shared.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        [Required(ErrorMessage = "El Monto no puede ser vació")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "La cantidad no puede ser vacia no puede ser vació")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La Fecha no puede ser vacia no puede ser vació")]
        public DateTime Fecha_venta { get; set; }

        [Required(ErrorMessage = "El cliente no puede ser vacia no puede ser vació")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public virtual ICollection<Producto>? Productos { get; set; }
        [NotMapped]
        public List<int>? ProductoIds { get; set; }
    }
}
