using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class AllergenService : IAllergenService
    {
        private readonly IAllergenRepository _allergenRepository;
        private readonly IMapper _mapper;

        public AllergenService(IAllergenRepository allergenRepository, IMapper mapper)
        {
            _allergenRepository = allergenRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllergenDTO>> GetAllAllergensAsync()
        {
            var allergens = await _allergenRepository.GetAllAllergensAsync();
            return _mapper.Map<IEnumerable<AllergenDTO>>(allergens);
        }

        public async Task<AllergenDTO> GetAllergenByIdAsync(int id)
        {
            var allergen = await _allergenRepository.GetAllergenByIdAsync(id);
            return _mapper.Map<AllergenDTO>(allergen);
        }

        public async Task<AllergenDTO> CreateAllergenAsync(AllergenDTO allergen)
        {
            var allergenModel = _mapper.Map<AllergenModel>(allergen);
            var createdAllergen = await _allergenRepository.CreateAllergenAsync(allergenModel);
            return _mapper.Map<AllergenDTO>(createdAllergen);
        }

        public async Task UpdateAllergenAsync(AllergenDTO allergen)
        {
            var allergenModel = _mapper.Map<AllergenModel>(allergen);
            await _allergenRepository.UpdateAllergenAsync(allergenModel);
        }

        public async Task DeleteAllergenAsync(int id)
        {
            await _allergenRepository.DeleteAllergenAsync(id);
        }
    }
}
