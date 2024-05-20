using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class TypeOfServingModel
    {
        public int TypeOfServingId { get; set; }
        public required string TypeOfServingName { get; set; }
        public ICollection<MenuProductPriceModel>? MenuProductPrice { get; set; }
    }
}
