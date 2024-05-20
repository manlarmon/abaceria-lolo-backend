using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class AllergenService : IAllergenService
    {
        private readonly IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public async Task<IEnumerable<AllergenModel>> GetAllAllergensAsync()
        {
            return await _allergenRepository.GetAllAllergensAsync();
        }

        public async Task<AllergenModel> GetAllergenByIdAsync(int id)
        {
            return await _allergenRepository.GetAllergenByIdAsync(id);
        }

        public async Task CreateAllergenAsync(AllergenModel allergen)
        {
            await _allergenRepository.CreateAllergenAsync(allergen);
        }

        public async Task UpdateAllergenAsync(AllergenModel allergen, int id)
        {
            await _allergenRepository.UpdateAllergenAsync(allergen, id);
        }

        public async Task DeleteAllergenAsync(int id)
        {
            await _allergenRepository.DeleteAllergenAsync(id);
        }

    }
}
