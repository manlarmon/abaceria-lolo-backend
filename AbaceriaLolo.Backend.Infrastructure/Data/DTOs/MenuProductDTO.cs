using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class MenuProductDTO
    {
        public int MenuProductId { get; set; }
        public string MenuProductName { get; set; }
        public bool IsVisible { get; set; }
        public int Order { get; set; }
        public int MenuSectionId { get; set; }
        public ICollection<MenuProductPriceDTO>? MenuProductPrices { get; set; }
        public ICollection<AllergenMenuProductDTO>? AllergenMenuProducts { get; set; }
    }

}
