using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
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

        public async Task<AllergenModel> CreateAllergenAsync(AllergenDTO allergen)
        {
            var alergenModel = new AllergenModel
            {
                AllergenId = 0,
                Abbreviation = allergen.Abbreviation,
                AllergenName = allergen.AllergenName
            };

            return await _allergenRepository.CreateAllergenAsync(alergenModel);
        }

        public async Task UpdateAllergenAsync(AllergenModel allergen)
        {
            await _allergenRepository.UpdateAllergenAsync(allergen);
        }

        public async Task DeleteAllergenAsync(int id)
        {
            await _allergenRepository.DeleteAllergenAsync(id);
        }

    }
}
