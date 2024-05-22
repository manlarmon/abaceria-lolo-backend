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
        public bool IsVisible { get; set; }
        public required string MenuProductName { get; set; }
        public int Order { get; set; }
        public int MenuSectionId { get; set; }
        
        [JsonIgnore]
        public MenuSectionModel? MenuSection { get; set; }
        [JsonIgnore]
        public ICollection<AllergenMenuProductModel>? AllergenMenuProduct { get; set; }
        [JsonIgnore]
        public ICollection<MenuProductPriceModel>? MenuProductPrice { get; set; }

    }
}
