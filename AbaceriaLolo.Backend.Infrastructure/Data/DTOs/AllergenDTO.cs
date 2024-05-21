using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class AllergenDTO
    {
        public required string Abbreviation { get; set; }
        public required string AllergenName { get; set; }
    }
}
