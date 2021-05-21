﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Przepisy_kulinarne_projekt.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Cat_Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
