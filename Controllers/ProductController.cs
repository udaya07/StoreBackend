using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreBackEnd.Dto;
using StoreBackEnd.Services;

namespace StoreBackEnd.Controllers
{
    [EnableCors("StorePolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;
       

        private ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
         
            this.logger = logger;
        }


        //get product details
        [HttpGet]
        [Route("{categoryid}")]
        public IActionResult GetProductDetails(int categoryid)
        {
            try
            {
                return Ok(productService.GetProductDetails(categoryid));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
                throw;
            }
        }
        //get products price
        [HttpGet]
        [Route("price/{productId}")]
        public IActionResult getPrice(int productId)
        {
            try
            {
                return Ok(productService.getProductPrice(productId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
                throw;
            }

        }
              //post cart details
              [HttpPost]
              [Route("AddToCart")]
              public bool Post([FromBody]AddToCartDto add)
              {
                  if (add != null)
                  {
                      var r = productService.PostCartDetails(add);
                      if (r == 1)
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

              //get cart details
             [HttpGet]
              [Route("ViewCart/{orderDetailsId}")]
              public IActionResult GetCartDetails(int orderDetailsId)
              {
                  try
                  {
                      return Ok(productService.GetCartDetails(orderDetailsId));
                  }
                  catch (Exception ex)
                  {
                      logger.LogError(ex, ex.Message);
                      return StatusCode(500);
                      throw;
                  }
              }


              [HttpPost]
              [Route("deleteFromCart")]
              public IActionResult delete(AddToCartDto delt)
              {
                  try
                  {
                      return Ok(productService.deleteFromCart(delt));
                  }
                  catch (Exception ex)
                  {
                      logger.LogError(ex, ex.Message);
                      return StatusCode(500);
                      throw;
                  }

              }

     
        //post cart details
        [HttpPost]
        [Route("placeOrder")]
        public bool placeOrder([FromBody]PostOrderDto add)
        {
            if (add != null)
            {
                var r = productService.PlaceOrder(add);
                if (r == 1)
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


        //get cart details
        [HttpGet]
        [Route("ViewOrders/{UserId}")]
        public IActionResult GetOrders(int UserId)
        {
            try
            {
                return Ok(productService.GetOrderDetails(UserId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
                throw;
            }
        }

        [HttpPatch("Purchased")]
        public IActionResult delet(PurchasedDto Ids)
        {
            if (Ids != null )
            {
                return Ok(productService.itemIsPurchased(Ids));
            }
            else
            {
                return BadRequest();
            }
        }












    }
}
