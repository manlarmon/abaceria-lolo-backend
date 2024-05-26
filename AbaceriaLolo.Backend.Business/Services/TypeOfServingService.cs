using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class TypeOfServingService : ITypeOfServingService
    {
        private readonly ITypeOfServingRepository _typeOfServingRepository;
        private readonly IMapper _mapper;

        public TypeOfServingService(ITypeOfServingRepository typeOfServingRepository, IMapper mapper)
        {
            _typeOfServingRepository = typeOfServingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeOfServingDTO>> GetAllTypesOfServingAsync()
        {
            var typesOfServing = await _typeOfServingRepository.GetAllTypesOfServingAsync();
            return _mapper.Map<IEnumerable<TypeOfServingDTO>>(typesOfServing);
        }

        public async Task<TypeOfServingDTO> GetTypeOfServingByIdAsync(int id)
        {
            var typeOfServing = await _typeOfServingRepository.GetTypeOfServingByIdAsync(id);
            return _mapper.Map<TypeOfServingDTO>(typeOfServing);
        }

        public async Task<TypeOfServingDTO> CreateTypeOfServingAsync(TypeOfServingDTO typeOfServing)
        {
            var typeOfServingModel = _mapper.Map<TypeOfServingModel>(typeOfServing);
            var createdTypeOfServing = await _typeOfServingRepository.CreateTypeOfServingAsync(typeOfServingModel);
            return _mapper.Map<TypeOfServingDTO>(createdTypeOfServing);
        }

        public async Task UpdateTypeOfServingAsync(TypeOfServingDTO typeOfServing)
        {
            var typeOfServingModel = _mapper.Map<TypeOfServingModel>(typeOfServing);
            await _typeOfServingRepository.UpdateTypeOfServingAsync(typeOfServingModel);
        }

        public async Task DeleteTypeOfServingAsync(int id)
        {
            await _typeOfServingRepository.DeleteTypeOfServingAsync(id);
        }
    }
}
