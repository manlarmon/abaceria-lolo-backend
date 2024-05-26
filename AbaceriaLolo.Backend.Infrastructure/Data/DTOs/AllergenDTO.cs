﻿using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Data.DTOs
{
    public class AllergenDTO
    {
        public int AllergenId { get; set; }
        public string AllergenName { get; set; }
        public string Abbreviation { get; set; }
    }
}
