using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventoryProductService
{
    Task<IEnumerable<InventoryProductDTO>> GetAllInventoryProductsAsync();
    Task<InventoryProductDTO> GetInventoryProductByIdAsync(int id);
    Task<InventoryProductDTO> CreateInventoryProductAsync(InventoryProductDTO inventoryProduct);
    Task UpdateInventoryProductAsync(InventoryProductDTO inventoryProduct);
    Task DeleteInventoryProductAsync(int id);
}
