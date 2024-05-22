using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class MenuSectionDTO
    {
        public bool IsVisible { get; set; }
        public required int Order { get; set; }
        public required string MenuSectionName { get; set; }
    }
}
