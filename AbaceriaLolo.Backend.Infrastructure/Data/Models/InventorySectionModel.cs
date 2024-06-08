public class InventorySectionModel
{
    public int InventorySectionId { get; set; }
    public string SectionName { get; set; }
    public bool IsActive { get; set; }
    public ICollection<InventoryProductModel> InventoryProducts { get; set; }
}
