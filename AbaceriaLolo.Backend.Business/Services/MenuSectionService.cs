using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuSectionService : IMenuSectionService
    {
        private readonly IMenuSectionRepository _menuSectionRepository;
        private readonly IMapper _mapper;

        public MenuSectionService(IMenuSectionRepository menuSectionRepository, IMapper mapper)
        {
            _menuSectionRepository = menuSectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuSectionDTO>> GetAllMenuSectionsAsync()
        {
            var menuSections = await _menuSectionRepository.GetAllMenuSectionsAsync();
            return _mapper.Map<IEnumerable<MenuSectionDTO>>(menuSections);
        }

        public async Task<MenuSectionDTO> GetMenuSectionByIdAsync(int id)
        {
            var menuSection = await _menuSectionRepository.GetMenuSectionByIdAsync(id);
            return _mapper.Map<MenuSectionDTO>(menuSection);
        }

        public async Task<MenuSectionDTO> CreateMenuSectionAsync(MenuSectionDTO menuSection)
        {
            var menuSectionModel = _mapper.Map<MenuSectionModel>(menuSection);
            var createdMenuSection = await _menuSectionRepository.CreateMenuSectionAsync(menuSectionModel);
            return _mapper.Map<MenuSectionDTO>(createdMenuSection);
        }

        public async Task UpdateMenuSectionAsync(MenuSectionDTO menuSection)
        {
            var menuSectionModel = _mapper.Map<MenuSectionModel>(menuSection);
            await _menuSectionRepository.UpdateMenuSectionAsync(menuSectionModel);
        }

        public async Task DeleteMenuSectionAsync(int id)
        {
            await _menuSectionRepository.DeleteMenuSectionAsync(id);
        }
    }
}
