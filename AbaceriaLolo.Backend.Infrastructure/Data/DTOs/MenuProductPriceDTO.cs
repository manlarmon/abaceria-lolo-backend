using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class MenuProductPriceDTO
    {
        public int MenuProductPriceId { get; set; }
        public int MenuProductId { get; set; }
        public int TypeOfServingId { get; set; }
        public TypeOfServingDTO? TypeOfServing { get; set; }
        public decimal Price { get; set; }
    }

}
