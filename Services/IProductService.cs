using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Services
{
  public  interface IProductService
    {
        IEnumerable<ProductDetailsDto> GetProductDetails(int categoryId);

        Product getProductPrice(int productId);

         int PostCartDetails(AddToCartDto dtls);

         IEnumerable<ViewCartDto> GetCartDetails(int orderDetailsId);  // get cart details

         string deleteFromCart(AddToCartDto delt);


        int PlaceOrder(PostOrderDto order);

        IEnumerable<YourOrdersDto> GetOrderDetails(int UserId);

        string itemIsPurchased(PurchasedDto Ids);



    }
}
