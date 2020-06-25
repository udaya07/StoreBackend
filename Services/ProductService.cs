using StoreBackEnd.Dto;
using StoreBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StoreBackEnd.Services
{
    public class ProductService : IProductService
    {
        AppDbContext appDbContext;
        public ProductService(AppDbContext appDbContext)
        {

            this.appDbContext = appDbContext;
        }

        //get product details and display in frontend
        public IEnumerable<ProductDetailsDto> GetProductDetails(int categoryId)
        {
            var productDetails = new List<ProductDetailsDto>();
            var productTypes = appDbContext.ProductType.Where(x => x.CategoryId == categoryId).ToList();
            foreach (var productType in productTypes)
            {

                var products = appDbContext.Product.Where(x => x.ProductTypeId == productType.Id).ToList();
                foreach (var product in products)
                {

                    var type = appDbContext.ProductType.Where(x => x.Id == product.ProductTypeId).FirstOrDefault();
                    var productDetail = new ProductDetailsDto
                    {
                        ProductType = type.ProdType,
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Specification = product.Specification,
                        Description = product.Description,
                        Picture = product.Picture,
                        Price = product.Price,
                        InStock = product.InStock



                    };
                    productDetails.Add(productDetail);

                }

            }
            var jsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(productDetails);
            return productDetails;

        }
        public Product getProductPrice(int productId)
        {
            try
            {
                var priceList = appDbContext.Product.Where(x => x.Id == productId).FirstOrDefault();

                return priceList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }













        //post addto cart details
        public int PostCartDetails(AddToCartDto dtls)
        {
            try
            {
                var result = (from r in appDbContext.AddToCart where (r.ProductId == dtls.ProductId && r.OrderDetailsId == dtls.OrderDetailsId && r.IsPurchased==false) select r).ToList();
                if (result.Count == 0)
                {
                    var product = appDbContext.Product.Where(x => x.Id == dtls.ProductId).FirstOrDefault();
                    var price = product.Price;
                    var qnty = dtls.Quantity;
                    var totalPrice = Convert.ToDouble(price) * qnty;
                    var info = new AddToCart
                    {
                        OrderDetailsId = dtls.OrderDetailsId,
                        ProductId = dtls.ProductId,
                        Quantity = dtls.Quantity,
                        TotalPrice = Convert.ToString(totalPrice),


                    };
                    appDbContext.AddToCart.Add(info);
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


        //get cart details
        public IEnumerable<ViewCartDto> GetCartDetails(int orderDetailsId)
        {
            try
            {

                var ViewCart = new List<ViewCartDto>();
                var productsLists = appDbContext.AddToCart.Where(x => x.OrderDetailsId == orderDetailsId && x.IsPurchased == false).ToList();
                foreach (var productsList in productsLists)
                {

                    var productDetails = appDbContext.Product.Where(x => x.Id == productsList.ProductId).ToList();
                    foreach (var productDetail in productDetails)
                    {
                        var products = appDbContext.ProductType.Where(x => x.Id == productDetail.ProductTypeId).FirstOrDefault();


                        var viewCart = new ViewCartDto
                        {
                            ProductType = products.ProdType,
                            ProductId = productDetail.Id,

                            ProductName = productDetail.ProductName,
                            Specification = productDetail.Specification,
                            Description = productDetail.Description,
                            Picture = productDetail.Picture,
                            Price = productDetail.Price,
                            TotalPrice = productsList.TotalPrice,
                            Quantity = productsList.Quantity,
                            OrderDetailsId = productsList.OrderDetailsId
                        };
                        ViewCart.Add(viewCart);
                    }
                }
                return ViewCart;
            }
            catch
            {
                return null;
            }

        }
        public string deleteFromCart(AddToCartDto delt)
        {
            try
            {

                var findElement = appDbContext.AddToCart.Where(x => x.ProductId == delt.ProductId && x.OrderDetailsId == delt.OrderDetailsId && x.IsPurchased == false).FirstOrDefault();
                var remove = appDbContext.AddToCart.Remove(findElement);
                appDbContext.SaveChanges();
                return "true";
            }
            catch
            {
                return "false";
            }

        }


        //post order
        public int PlaceOrder(PostOrderDto order)
        {
            try
            {
                var CartRow = appDbContext.AddToCart.Where(x => x.OrderDetailsId == order.OrderDetailsId && x.ProductId == order.ProductId && x.IsPurchased == false).FirstOrDefault();
                var cartId = CartRow.Id;
                var orderStatusPlaced = appDbContext.Status.Where(x => x.StatusName == "OrderPlaced").FirstOrDefault();
                var statusId = orderStatusPlaced.Id;
                var neworder = new Orders
                {
                    CartId = cartId,
                    OrderDate = order.OrderDate,
                    StatusId = statusId,
                    OrderTime = order.OrderDate
                };
                appDbContext.Orders.Add(neworder);
                appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // view orders
        public IEnumerable<YourOrdersDto> GetOrderDetails(int UserId)
        {
            try {
                var yourOrders = new List<YourOrdersDto>();
                var orderDetails = appDbContext.OrderDetails.Where(x => x.UserId == UserId).FirstOrDefault();
                var orderDetailsId = orderDetails.Id;
                var cartDetails = appDbContext.AddToCart.Where(x => x.OrderDetailsId == orderDetailsId).ToList();

                foreach (var cartDetail in cartDetails)
                {
                    var productDetails = appDbContext.Product.Where(x => x.Id == cartDetail.ProductId).ToList();
                    foreach (var productDetail in productDetails)
                    {
                        var productType = appDbContext.ProductType.Where(x => x.Id == productDetail.ProductTypeId).FirstOrDefault();
                        var cartIds = appDbContext.Orders.Where(x => x.CartId == cartDetail.Id).ToList();

                        foreach (var cartId in cartIds)
                        {
                            var timeIst = TimeZoneInfo.ConvertTimeFromUtc(cartId.OrderTime,TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                            var dateIst = TimeZoneInfo.ConvertTimeFromUtc(cartId.OrderDate,
                          TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                            var status = appDbContext.Status.Where(x => x.Id == cartId.StatusId).FirstOrDefault();                            var yourorders = new YourOrdersDto
                            {
                                ProductId = productDetail.Id,
                                ProductType = productType.ProdType,
                                ProductName = productDetail.ProductName,
                                Specification = productDetail.Specification,
                                Description = productDetail.Description,
                                Picture = productDetail.Picture,
                                Price = productDetail.Price,
                                TotalPrice = cartDetail.TotalPrice,
                                Quantity = cartDetail.Quantity,
                                OrderDetailsId = cartDetail.OrderDetailsId,
                                StatusId = cartId.StatusId,
                                OrderDate = dateIst,
                                OrderTime = timeIst,
                                OrderYear = dateIst.Year.ToString(),
                                OrderMonth = dateIst.Month.ToString(),
                                OrderDay = dateIst.Day.ToString(),
                                OrderHour = dateIst.Hour.ToString(),
                                OrderMinutes =dateIst.Minute.ToString(),

                                StatusName = status.StatusName

                            };
                            yourOrders.Add(yourorders);
                        }
                    }
                }
                return yourOrders;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //change to item IsPurchased
         public string itemIsPurchased(PurchasedDto Ids)
        {
            try
            {


                var change = appDbContext.AddToCart.Where(x => x.ProductId == Ids.productId && x.OrderDetailsId ==Ids.orderDetailsId && x.IsPurchased == false).FirstOrDefault();
                change.IsPurchased = true;

                appDbContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                throw;
            }
        }






    }
}