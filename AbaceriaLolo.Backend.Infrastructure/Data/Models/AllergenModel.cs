using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class AllergenModel
    {
        public int AllergenId { get; set; }
        public required string AllergenName { get; set; }
        public ICollection<AllergenMenuProductModel>? AllergenMenuProduct { get; set; }
    }
}
