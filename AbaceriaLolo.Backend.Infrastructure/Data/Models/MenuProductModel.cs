using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class MenuProductModel
    {
        public int MenuProductId { get; set; }
        public string? MenuProductName { get; set; }
        public bool IsVisible { get; set; }
        public int Order { get; set; }
        public int MenuSectionId { get; set; }
        public MenuSectionModel? MenuSection { get; set; }
        public ICollection<MenuProductPriceModel>? MenuProductPrice { get; set; }
        public ICollection<AllergenMenuProductModel>? AllergenMenuProduct { get; set; }
    }
}
