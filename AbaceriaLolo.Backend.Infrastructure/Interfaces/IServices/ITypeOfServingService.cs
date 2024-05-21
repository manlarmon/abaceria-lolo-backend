using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface ITypeOfServingService
    {
        Task<IEnumerable<TypeOfServingModel>> GetAllTypesOfServingAsync();
        Task<TypeOfServingModel> GetTypeOfServingByIdAsync(int id);
        Task<TypeOfServingModel> CreateTypeOfServingAsync(TypeOfServingDTO typeOfServing);
        Task UpdateTypeOfServingAsync(TypeOfServingModel typeOfServing);
        Task DeleteTypeOfServingAsync(int id);
    }
}
