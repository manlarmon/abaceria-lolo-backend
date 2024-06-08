using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public class InventorySectionService : IInventorySectionService
{
    private readonly IInventorySectionRepository _inventorySectionRepository;
    private readonly IMapper _mapper;

    public InventorySectionService(IInventorySectionRepository inventorySectionRepository, IMapper mapper)
    {
        _inventorySectionRepository = inventorySectionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InventorySectionDTO>> GetAllInventorySectionsAsync()
    {
        var sections = await _inventorySectionRepository.GetAllInventorySectionsAsync();
        return _mapper.Map<IEnumerable<InventorySectionDTO>>(sections);
    }

    public async Task<InventorySectionDTO> GetInventorySectionByIdAsync(int id)
    {
        var section = await _inventorySectionRepository.GetInventorySectionByIdAsync(id);
        return _mapper.Map<InventorySectionDTO>(section);
    }

    public async Task<InventorySectionDTO> CreateInventorySectionAsync(InventorySectionDTO inventorySection)
    {
        var sectionModel = _mapper.Map<InventorySectionModel>(inventorySection);
        var createdSection = await _inventorySectionRepository.CreateInventorySectionAsync(sectionModel);
        return _mapper.Map<InventorySectionDTO>(createdSection);
    }

    public async Task UpdateInventorySectionAsync(InventorySectionDTO inventorySection)
    {
        var sectionModel = _mapper.Map<InventorySectionModel>(inventorySection);
        await _inventorySectionRepository.UpdateInventorySectionAsync(sectionModel);
    }

    public async Task DeleteInventorySectionAsync(int id)
    {
        await _inventorySectionRepository.DeleteInventorySectionAsync(id);
    }
}
