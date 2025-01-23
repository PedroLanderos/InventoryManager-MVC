using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Nombre { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [EmailAddress]
        public string? Correo { get; set; }

        // Relación uno a muchos
        public ICollection<Product>? Productos { get; set; }
    }
}
