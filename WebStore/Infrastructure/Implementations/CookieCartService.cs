using System;
using Microsoft.AspNetCore.Http;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class CookieCartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string _CartName;

        public CookieCartService(IProductData ProductData, IHttpContextAccessor HttpContextAccessor)
        {
            _ProductData = ProductData;
            _HttpContextAccessor = HttpContextAccessor;
            var user_identity = HttpContextAccessor.HttpContext.User.Identity;
            _CartName = $"cart{(user_identity.IsAuthenticated ? user_identity.Name : null)}";
        }

        public void AddToCart(int id)
        {
            throw new NotImplementedException();
        }

        public void DecrementFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public CartViewModel TransformCart()
        {
            throw new NotImplementedException();
        }
    }
}
