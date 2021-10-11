using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazingShop.Shared
{
    public class ProductVariant
    {
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
        
        public int EditionId { get; set; }


        public Edition Edition { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

    }
}
