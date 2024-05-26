using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IAllergenRepository
    {
        Task<IEnumerable<AllergenModel>> GetAllAllergensAsync();
        Task<AllergenModel> GetAllergenByIdAsync(int id);
        Task<AllergenModel> CreateAllergenAsync(AllergenModel allergen);
        Task<AllergenModel> UpdateAllergenAsync(AllergenModel allergen);
        Task DeleteAllergenAsync(int id);
    }
}
