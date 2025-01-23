using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        // Relación uno a muchos
        public ICollection<Product>? Productos { get; set; }
    }
}
