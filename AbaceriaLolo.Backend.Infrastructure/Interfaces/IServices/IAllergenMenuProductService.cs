using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IAllergenMenuProductService
    {
        Task<IEnumerable<AllergenMenuProductDTO>> GetAllAllergenMenuProductsAsync();
        Task<AllergenMenuProductDTO> GetAllergenMenuProductByIdAsync(int id);
        Task<AllergenMenuProductDTO> CreateAllergenMenuProductAsync(AllergenMenuProductDTO allergenMenuProduct);
        Task UpdateAllergenMenuProductAsync(AllergenMenuProductDTO allergenMenuProduct);
        Task DeleteAllergenMenuProductAsync(int id);
    }
}
