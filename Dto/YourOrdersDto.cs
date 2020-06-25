using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class YourOrdersDto
    {
        public int ProductId { get; set; }


        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public string Price { get; internal set; }

        public string TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderDetailsId { get; set; }

        public int StatusId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }

        public string StatusName { get; set; }

        public string OrderYear { get; set; }
        public string OrderMonth { get; set; }
        public string OrderDay { get; set; }
        public string OrderHour { get; set; }
        public string OrderMinutes { get; set; }

    }
}
