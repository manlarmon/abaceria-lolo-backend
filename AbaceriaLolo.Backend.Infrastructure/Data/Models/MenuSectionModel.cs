using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class MenuSectionModel
    {
        public int MenuSectionId { get; set; }
        //public bool IsVisible { get; set; }
        public int Order { get; set; }
        public required string MenuSectionName { get; set; }

        public ICollection<MenuProductModel>? MenuProducts { get; set; }

    }
}
