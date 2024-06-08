using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public class InventoryProductService : IInventoryProductService
{
    private readonly IInventoryProductRepository _inventoryProductRepository;
    private readonly IMapper _mapper;

    public InventoryProductService(IInventoryProductRepository inventoryProductRepository, IMapper mapper)
    {
        _inventoryProductRepository = inventoryProductRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InventoryProductDTO>> GetAllInventoryProductsAsync()
    {
        var products = await _inventoryProductRepository.GetAllInventoryProductsAsync();
        return _mapper.Map<IEnumerable<InventoryProductDTO>>(products);
    }

    public async Task<InventoryProductDTO> GetInventoryProductByIdAsync(int id)
    {
        var product = await _inventoryProductRepository.GetInventoryProductByIdAsync(id);
        return _mapper.Map<InventoryProductDTO>(product);
    }

    public async Task<InventoryProductDTO> CreateInventoryProductAsync(InventoryProductDTO inventoryProduct)
    {
        var productModel = _mapper.Map<InventoryProductModel>(inventoryProduct);
        var createdProduct = await _inventoryProductRepository.CreateInventoryProductAsync(productModel);
        return _mapper.Map<InventoryProductDTO>(createdProduct);
    }

    public async Task UpdateInventoryProductAsync(InventoryProductDTO inventoryProduct)
    {
        var productModel = _mapper.Map<InventoryProductModel>(inventoryProduct);
        await _inventoryProductRepository.UpdateInventoryProductAsync(productModel);
    }

    public async Task DeleteInventoryProductAsync(int id)
    {
        await _inventoryProductRepository.DeleteInventoryProductAsync(id);
    }
}
