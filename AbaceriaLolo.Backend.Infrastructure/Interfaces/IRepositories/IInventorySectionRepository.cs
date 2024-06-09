using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventorySectionRepository
{
    Task<IEnumerable<InventorySectionModel>> GetAllInventorySectionsAsync();
    Task<InventorySectionModel> GetInventorySectionByIdAsync(int id);
    Task<InventorySectionModel> CreateInventorySectionAsync(InventorySectionModel inventorySection);
    Task<InventorySectionModel> UpdateInventorySectionAsync(InventorySectionModel inventorySection);
    Task DeleteInventorySectionAsync(int id);
}
