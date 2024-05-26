using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface ITypeOfServingRepository
    {
        Task<IEnumerable<TypeOfServingModel>> GetAllTypesOfServingAsync();
        Task<TypeOfServingModel> GetTypeOfServingByIdAsync(int id);
        Task<TypeOfServingModel> CreateTypeOfServingAsync(TypeOfServingModel typeOfServing);
        Task<TypeOfServingModel> UpdateTypeOfServingAsync(TypeOfServingModel typeOfServing);
        Task DeleteTypeOfServingAsync(int id);
    }
}
