using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Services
{
    public class OrdersService : IOrdersService
    {
        AppDbContext appDbContext;
        public OrdersService(AppDbContext appDbContext)
        {

            this.appDbContext = appDbContext;
        }

        //post order details
        public int PostOrderDetails(OrderDetailsDto detail)
        {
            try
            {
                var result = (from r in appDbContext.OrderDetails where (r.UserId == detail.UserId) select r).ToList();
                if (result.Count == 0)
                {
                    var info = new OrderDetails
                    {
                        UserId = detail.UserId,
                        DeliverTo = detail.DeliverTo,
                        ContactNo = detail.ContactNo,
                        DeliveryAddress = detail.DeliveryAddress,
                        Pincode = detail.Pincode,


                    };
                    appDbContext.OrderDetails.Add(info);
                    appDbContext.SaveChanges();
                    return 1;

                }

                else
                {
                    return 0;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //get address
        public OrderDetails getAddress(int userId)
        {
            try
            {
                var address = appDbContext.OrderDetails.Where(x => x.UserId == userId).FirstOrDefault();

                return address;
            }
            catch (Exception ex)
            {
              
                throw;
            }
        }

        // filter address

        public OrderDetails filterAddress(int orderDetailsId)
        {
            try
            {
                var res = appDbContext.OrderDetails.Where(x => x.Id == orderDetailsId).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //update delivery details
        public string updateDeliveryDetails(int id, OrderDetailsDto chng)
        {
            try
            {


                var update = appDbContext.OrderDetails.Where(x => x.Id == id).SingleOrDefault();
                update.UserId = chng.UserId;
                update.DeliverTo = chng.DeliverTo;
                update.ContactNo = chng.ContactNo;
                update.DeliveryAddress= chng.DeliveryAddress;
                update.Pincode = chng.Pincode;

                appDbContext.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }

        public int getOrderDetailsId(int userId)
        {
            try
            {
                var OrdrDtlsId = appDbContext.OrderDetails.Where(x => x.UserId == userId).FirstOrDefault();

                return OrdrDtlsId.Id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
