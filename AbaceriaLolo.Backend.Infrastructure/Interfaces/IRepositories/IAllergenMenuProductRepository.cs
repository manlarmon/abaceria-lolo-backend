using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IAllergenMenuProductRepository
    {
        Task<IEnumerable<AllergenMenuProductModel>> GetAllAllergenMenuProductsAsync();
        Task<AllergenMenuProductModel> GetAllergenMenuProductByIdAsync(int id);
        Task<AllergenMenuProductModel> CreateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct);
        Task UpdateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct);
        Task DeleteAllergenMenuProductAsync(int id);
    }
}
