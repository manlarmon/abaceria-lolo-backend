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
        public required string MenuProductName { get; set; }
        public int MenuSectionId { get; set; }
        public int Order { get; set; }

    }
}
