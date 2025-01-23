using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        // Relaciones
        public int CategoriaId { get; set; }
        public Category? Categoria { get; set; }

        public int ProveedorId { get; set; }
        public Provider? Proveedor { get; set; }
    }
}
