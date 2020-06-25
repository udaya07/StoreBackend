﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class PostOrderDto
    {
        public int OrderDetailsId { get; set; }
        public int ProductId { get; set; }

        public int CartId { get; set; }
    
        public DateTime OrderDate { get; set; }
    }
}
