using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.Entities.Entries;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Infrastructure.Implementations
{
    public class CookieCartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string _CartName;

        private Cart Cart
        {
            get
            {
                var http_context = _HttpContextAccessor.HttpContext;
                var cookie = http_context.Request.Cookies[_CartName];
                Cart cart = null;
                if (cookie is null)
                {
                    cart = new Cart();
                    http_context.Response.Cookies.Append(_CartName, JsonConvert.SerializeObject(cart), new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
                }
                else
                {
                    cart = JsonConvert.DeserializeObject<Cart>(cookie);
                    http_context.Response.Cookies.Delete(_CartName);
                    http_context.Response.Cookies.Append(_CartName, cookie, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
                }

                return cart;
            }
            set
            {
                var http_context = _HttpContextAccessor.HttpContext;
                var json = JsonConvert.SerializeObject(value);
                http_context.Response.Cookies.Delete(_CartName);
                http_context.Response.Cookies.Append(_CartName, json, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1)
                });
            }
        }

        public CookieCartService(IProductData ProductData, IHttpContextAccessor HttpContextAccessor)
        {
            _ProductData = ProductData;
            _HttpContextAccessor = HttpContextAccessor;
            var user_identity = HttpContextAccessor.HttpContext.User.Identity;
            _CartName = $"cart{(user_identity.IsAuthenticated ? user_identity.Name : null)}";
        }

        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                item.Quantity++;

            Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null) return;
            if (item.Quantity > 0)
                item.Quantity--;
            if (item.Quantity == 0)
                cart.Items.Remove(item);

            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null) return;
            cart.Items.Remove(item);
            Cart = cart;
        }

        public void RemoveAll() => Cart = new Cart();

        public CartViewModel TransformCart()
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(i => i.ProductId).ToArray()
            }).Select(p => new ProductViewModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand is null ? string.Empty : p.Brand.Name
            }).ToArray();

            return new CartViewModel
            {
                Items = Cart.Items.ToDictionary(i => products.First(p => p.Id == i.ProductId), i => i.Quantity)
            };
        }
    }
}
