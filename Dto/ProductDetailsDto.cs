﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class ProductDetailsDto
    {
      
        public int ProductId { get; set; }

       
        public string ProductType { get; set; }

      
        public string ProductName { get; set; }


        public string Specification { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public string Price { get; internal set; }

        public string InStock { get; set; }
    }

}
