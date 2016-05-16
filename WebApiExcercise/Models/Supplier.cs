﻿using System;
using System.Collections.Generic;

namespace WebApiExcercise.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}