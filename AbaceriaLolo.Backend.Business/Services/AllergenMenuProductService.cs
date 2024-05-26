using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class AllergenMenuProductService : IAllergenMenuProductService
    {
        private readonly IAllergenMenuProductRepository _allergenMenuProductRepository;
        private readonly IMapper _mapper;

        public AllergenMenuProductService(IAllergenMenuProductRepository allergenMenuProductRepository, IMapper mapper)
        {
            _allergenMenuProductRepository = allergenMenuProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllergenMenuProductDTO>> GetAllAllergenMenuProductsAsync()
        {
            var allergenMenuProducts = await _allergenMenuProductRepository.GetAllAllergenMenuProductsAsync();
            return _mapper.Map<IEnumerable<AllergenMenuProductDTO>>(allergenMenuProducts);
        }

        public async Task<AllergenMenuProductDTO> GetAllergenMenuProductByIdAsync(int id)
        {
            var allergenMenuProduct = await _allergenMenuProductRepository.GetAllergenMenuProductByIdAsync(id);
            return _mapper.Map<AllergenMenuProductDTO>(allergenMenuProduct);
        }

        public async Task<AllergenMenuProductDTO> CreateAllergenMenuProductAsync(AllergenMenuProductDTO allergenMenuProduct)
        {
            var allergenMenuProductModel = _mapper.Map<AllergenMenuProductModel>(allergenMenuProduct);
            var createdAllergenMenuProduct = await _allergenMenuProductRepository.CreateAllergenMenuProductAsync(allergenMenuProductModel);
            return _mapper.Map<AllergenMenuProductDTO>(createdAllergenMenuProduct);
        }

        public async Task UpdateAllergenMenuProductAsync(AllergenMenuProductDTO allergenMenuProduct)
        {
            var allergenMenuProductModel = _mapper.Map<AllergenMenuProductModel>(allergenMenuProduct);
            await _allergenMenuProductRepository.UpdateAllergenMenuProductAsync(allergenMenuProductModel);
        }

        public async Task DeleteAllergenMenuProductAsync(int id)
        {
            await _allergenMenuProductRepository.DeleteAllergenMenuProductAsync(id);
        }
    }
}
