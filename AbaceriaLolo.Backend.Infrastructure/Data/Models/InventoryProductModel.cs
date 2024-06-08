public class InventoryProductModel
{
    public int InventoryProductId { get; set; }
    public int InventorySectionId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public InventorySectionModel InventorySection { get; set; }
}
