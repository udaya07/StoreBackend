using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Dto
{
    public class OrderDetailsDto
    {
        public int UserId { get; set; }

        public string DeliverTo { get; set; }

        public string ContactNo { get; set; }


        public string DeliveryAddress { get; set; }

        public string Pincode { get; set; }

    }
}
