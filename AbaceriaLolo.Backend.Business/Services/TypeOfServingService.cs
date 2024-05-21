using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class TypeOfServingService : ITypeOfServingService
    {
        private readonly ITypeOfServingRepository _typeOfServingRepository;

        public TypeOfServingService(ITypeOfServingRepository typeOfServingRepository)
        {
            _typeOfServingRepository = typeOfServingRepository;
        }

        public async Task<IEnumerable<TypeOfServingModel>> GetAllTypesOfServingAsync()
        {
            return await _typeOfServingRepository.GetAllTypesOfServingAsync();
        }

        public async Task<TypeOfServingModel> GetTypeOfServingByIdAsync(int id)
        {
            return await _typeOfServingRepository.GetTypeOfServingByIdAsync(id);
        }

        public async Task<TypeOfServingModel> CreateTypeOfServingAsync(TypeOfServingDTO typeOfServing)
        {
            var typeOfServingModel = new TypeOfServingModel
            {
                TypeOfServingId = 0,
                TypeOfServingName = typeOfServing.TypeOfServingName
            };
            return await _typeOfServingRepository.CreateTypeOfServingAsync(typeOfServingModel);
        }

        public async Task UpdateTypeOfServingAsync(TypeOfServingModel typeOfServing)
        {
            await _typeOfServingRepository.UpdateTypeOfServingAsync(typeOfServing);
        }

        public async Task DeleteTypeOfServingAsync(int id)
        {
            await _typeOfServingRepository.DeleteTypeOfServingAsync(id);
        }
    }
}
