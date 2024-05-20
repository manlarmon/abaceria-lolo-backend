using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class AllergenMenuProductModel
    {
        public int AllergenMenuProductId { get; set; }
        public int AllergenId { get; set; }
        public int MenuProductId { get; set; }
        public virtual AllergenModel? Allergen { get; set; }
        public virtual MenuProductModel? MenuProduct { get; set; }
    }
}
