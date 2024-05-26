using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface ITypeOfServingService
    {
        Task<IEnumerable<TypeOfServingDTO>> GetAllTypesOfServingAsync();
        Task<TypeOfServingDTO> GetTypeOfServingByIdAsync(int id);
        Task<TypeOfServingDTO> CreateTypeOfServingAsync(TypeOfServingDTO typeOfServing);
        Task UpdateTypeOfServingAsync(TypeOfServingDTO typeOfServing);
        Task DeleteTypeOfServingAsync(int id);
    }
}
