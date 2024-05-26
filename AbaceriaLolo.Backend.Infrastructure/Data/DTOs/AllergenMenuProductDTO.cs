using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class AllergenMenuProductDTO
    {
        public int AllergenMenuProductId { get; set; }
        public int AllergenId { get; set; }
        public int MenuProductId { get; set; }
        public AllergenDTO? Allergen { get; set; }
        public MenuProductDTO? MenuProduct { get; set; }
    }
}
