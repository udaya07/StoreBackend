using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using StoreBackEnd.Services;

namespace StoreBackEnd.Controllers
{
    [EnableCors("StorePolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersService ordersService;
        private ILogger<OrdersController> logger;

        public OrdersController(IOrdersService ordersService, ILogger<OrdersController> logger)
        {
            this.ordersService = ordersService;
            this.logger = logger;
        }

        //post cart details
        [HttpPost]
        [Route("AddDeliveryDetails")]
        public bool Post([FromBody]OrderDetailsDto add)
        {
            if (add != null)
            {
                var deliveryDetails = ordersService.PostOrderDetails(add);
                if (deliveryDetails == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        [HttpGet]

        [Route("deliveryDetails/{userId}")]
        public  IActionResult Get(int userId)
        {
            if (userId != 0)
            {
                return Ok(ordersService.getAddress(userId));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("filterDetails/{orderDetailsId}")]
        public IActionResult GetDetails(int orderDetailsId)
        {
            if (orderDetailsId != 0)
            {
                return Ok(ordersService.filterAddress(orderDetailsId));
            }
            else
            {
                return BadRequest();
            }

        }

        //update order details
        [HttpPut]
        [Route("updateDeliveryDetails/{id}")]
        public bool Put(int id, [FromBody] OrderDetailsDto edit)
        {
            if (id != null && edit != null)
            {
                var r = ordersService.updateDeliveryDetails(id, edit);
                if (r == "Updated")
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        [Route("orderDetailsId/{userId}")]
        public IActionResult GetId(int userId)
        {
            if (userId != 0)
            {
               var result =ordersService.getOrderDetailsId(userId);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
