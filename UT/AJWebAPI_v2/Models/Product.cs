﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJWebAPI_v2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}