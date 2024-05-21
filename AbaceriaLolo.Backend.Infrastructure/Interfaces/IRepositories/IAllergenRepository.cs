using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IAllergenRepository
    {
        Task<IEnumerable<AllergenModel>> GetAllAllergensAsync();
        Task<AllergenModel> GetAllergenByIdAsync(int id);
        Task<AllergenModel> CreateAllergenAsync(AllergenModel allergen);
        Task UpdateAllergenAsync(AllergenModel allergen);
        Task DeleteAllergenAsync(int id);

    }
}
