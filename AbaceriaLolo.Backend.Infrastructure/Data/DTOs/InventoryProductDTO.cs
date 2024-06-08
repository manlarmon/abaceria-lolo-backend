using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;

public class InventoryProductDTO
{
    public int InventoryProductId { get; set; }
    public int InventorySectionId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
