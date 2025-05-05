using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductosAPI.Dtos.Productos
{
    public class ProductoSaveDto
    {

        [StringLength(20)]
        [Required]
        public string? Nombre { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        public string? Estado { get; set; }
    }
}
