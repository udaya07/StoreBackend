using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class AddToCartDto
    {
        public int OrderDetailsId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string TotalPrice { get; set; }
  
    }

}
