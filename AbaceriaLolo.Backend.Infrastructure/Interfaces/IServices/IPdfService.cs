using System.Collections.Generic;
using System.Threading.Tasks;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IPdfService
    {
        Task<byte[]> GenerateInventoryPdfAsync(IEnumerable<InventorySectionModel> inventorySections);
    }
}
