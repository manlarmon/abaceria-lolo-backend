using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class MenuProductModel
    {
        public int MenuProductId { get; set; }
        public required string MenuProductName { get; set; }
        public int Order { get; set; }
        public int MenuSectionId { get; set; }
        public MenuSectionModel? MenuSection { get; set; }
        public ICollection<AllergenMenuProductModel>? AllergenMenuProduct { get; set; }
        public ICollection<MenuProductPriceModel>? MenuProductPrice { get; set; }

    }
}
