using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IAllergenService
    {
        Task<IEnumerable<AllergenModel>> GetAllAllergensAsync();
        Task<AllergenModel> GetAllergenByIdAsync(int id);
        Task<AllergenModel> CreateAllergenAsync(AllergenDTO allergen);
        Task UpdateAllergenAsync(AllergenModel allergen);
        Task DeleteAllergenAsync(int id);
    }
}
