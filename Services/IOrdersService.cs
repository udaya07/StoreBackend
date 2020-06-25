using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Services
{
   public interface IOrdersService
    {
        int PostOrderDetails(OrderDetailsDto detail);

       OrderDetails getAddress(int userId);
        OrderDetails filterAddress(int orderDetailsId);
        string updateDeliveryDetails(int id, OrderDetailsDto chng);

        int getOrderDetailsId(int userId);

    }
}
