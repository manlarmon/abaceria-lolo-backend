using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventoryProductRepository
{
    Task<IEnumerable<InventoryProductModel>> GetAllInventoryProductsAsync();
    Task<InventoryProductModel> GetInventoryProductByIdAsync(int id);
    Task<InventoryProductModel> CreateInventoryProductAsync(InventoryProductModel inventoryProduct);
    Task<InventoryProductModel> UpdateInventoryProductAsync(InventoryProductModel inventoryProduct);
    Task DeleteInventoryProductAsync(int id);
}
