using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiForPryaniky.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController
    {
        [HttpGet("list")]
        public CartListResponse Get()
        {
            var totalPrice = 0;
            foreach (var product in Cart.Products.Values)
            {
                totalPrice += product.Count * product.Product.Price;
            }
            return new CartListResponse
            {
                Products = Cart.Products.Values,
                TotalPrice = totalPrice,
            };
        }

        [HttpPost("update")]
        public AddToCartResponce Update(AddToCartRequest request)
        {
            if (request.Count == 0)
            {
                return new AddToCartResponce
                {
                    ErrorMessage = "Невозможно изменить состояние корзины с 0 преданных продуктов.",
                    IsOk = false,
                };
            }
            lock(Cart.LockObject)
            {
                if (Cart.Products.ContainsKey(request.Id))
                {
                    var beforeCount = Cart.Products.Count;
                    var afterCount = beforeCount + request.Count;
                    if (afterCount > 0)
                    {
                        Cart.Products[request.Id].Count = afterCount;
                    }
                    else
                    {
                        Cart.Products.Remove(request.Id);
                    }
                    return new AddToCartResponce
                    {
                        ErrorMessage = String.Empty,
                        IsOk = true,
                    };
                }
                else
                {
                    if (Product.AllProducts.ContainsKey(request.Id))
                    {
                        if (request.Count < 0)
                        {
                            return new AddToCartResponce
                            {
                                ErrorMessage = "Недобавленные продукты нельзя удалить",
                                IsOk = false,
                            };
                        }

                        var cartProduct = new CartProduct
                        {
                            Count = request.Count,
                            Product = Product.AllProducts[request.Id],
                        };

                        Cart.Products.Add(request.Id, cartProduct);
                        return new AddToCartResponce
                        {
                            ErrorMessage = String.Empty,
                            IsOk = true,
                        };
                    }
                    else
                    {
                        return new AddToCartResponce
                        {
                            ErrorMessage = "Переданный продукт не существует",
                            IsOk = false,
                        };
                    }
                }
            }
        }
    }
}
