using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IAllergenService
    {
        Task<IEnumerable<AllergenModel>> GetAllAllergensAsync();
        Task<AllergenModel> GetAllergenByIdAsync(int id);
        Task CreateAllergenAsync(AllergenModel allergen);
        Task UpdateAllergenAsync(AllergenModel allergen, int id);
        Task DeleteAllergenAsync(int id);
    }
}
