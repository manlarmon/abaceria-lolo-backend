using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class AllergenMenuProductService : IAllergenMenuProductService
    {
        private readonly IAllergenMenuProductRepository _allergenMenuProductRepository;

        public AllergenMenuProductService(IAllergenMenuProductRepository allergenMenuProductRepository)
        {
            _allergenMenuProductRepository = allergenMenuProductRepository;
        }

        public async Task<IEnumerable<AllergenMenuProductModel>> GetAllAllergenMenuProductsAsync()
        {
            return await _allergenMenuProductRepository.GetAllAllergenMenuProductsAsync();
        }

        public async Task<AllergenMenuProductModel> GetAllergenMenuProductByIdAsync(int id)
        {
            return await _allergenMenuProductRepository.GetAllergenMenuProductByIdAsync(id);
        }

        public async Task<AllergenMenuProductModel> CreateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct)
        {
            return await _allergenMenuProductRepository.CreateAllergenMenuProductAsync(allergenMenuProduct);
        }

        public async Task UpdateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct)
        {
            await _allergenMenuProductRepository.UpdateAllergenMenuProductAsync(allergenMenuProduct);
        }

        public async Task DeleteAllergenMenuProductAsync(int id)
        {
            await _allergenMenuProductRepository.DeleteAllergenMenuProductAsync(id);
        }
    }
}
