namespace InventoryManager.DTOs
{
    public record ProductDTO(string Nombre, string Descripcion, decimal Precio, int Stock, int CategoriaId);
    
}
