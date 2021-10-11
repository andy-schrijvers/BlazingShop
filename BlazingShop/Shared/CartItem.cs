﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.Shared
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int EditionId { get; set; }
        public string ProductTitle { get; set; }
        public string EditionName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
