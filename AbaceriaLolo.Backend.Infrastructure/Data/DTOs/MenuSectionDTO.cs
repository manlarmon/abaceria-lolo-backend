using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class MenuSectionDTO
    {
        public int MenuSectionId { get; set; }
        public string? MenuSectionName { get; set; }
        public bool IsVisible { get; set; }
        public int Order { get; set; }
        public ICollection<MenuProductDTO>? MenuProducts { get; set; }
    }

}
