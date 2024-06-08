using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventorySectionService
{
    Task<IEnumerable<InventorySectionDTO>> GetAllInventorySectionsAsync();
    Task<InventorySectionDTO> GetInventorySectionByIdAsync(int id);
    Task<InventorySectionDTO> CreateInventorySectionAsync(InventorySectionDTO inventorySection);
    Task UpdateInventorySectionAsync(InventorySectionDTO inventorySection);
    Task DeleteInventorySectionAsync(int id);
}
