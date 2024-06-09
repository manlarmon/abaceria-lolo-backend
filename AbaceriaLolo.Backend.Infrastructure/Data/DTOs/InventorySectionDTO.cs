using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;

public class InventorySectionDTO
{
    public int InventorySectionId { get; set; }
    public string SectionName { get; set; }
    public bool IsActive { get; set; }
    public ICollection<InventoryProductDTO>? InventoryProducts { get; set; }

}
