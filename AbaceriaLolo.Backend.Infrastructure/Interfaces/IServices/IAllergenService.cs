using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IAllergenService
    {
        Task<IEnumerable<AllergenDTO>> GetAllAllergensAsync();
        Task<AllergenDTO> GetAllergenByIdAsync(int id);
        Task<AllergenDTO> CreateAllergenAsync(AllergenDTO allergen);
        Task UpdateAllergenAsync(AllergenDTO allergen);
        Task DeleteAllergenAsync(int id);
    }
}
