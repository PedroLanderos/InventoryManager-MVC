namespace InventoryManager.Models
{
    public class LogInventory
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }
        public Product? Producto { get; set; }

        public int CambioStock { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string? UsuarioId { get; set; } // ID del usuario que realizó el cambio
    }
}
