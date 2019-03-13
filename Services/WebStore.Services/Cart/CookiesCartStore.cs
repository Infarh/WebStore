using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Cart
{
    public class CookiesCartStore : ICartStore
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string _CartName;

        public Entities.ViewModels.Cart Cart
        {
            get
            {
                var http_context = _HttpContextAccessor.HttpContext;
                var cookie = http_context.Request.Cookies[_CartName];
                Entities.ViewModels.Cart cart = null;
                if (cookie is null)
                {
                    cart = new Entities.ViewModels.Cart();
                    http_context.Response.Cookies.Append(_CartName, JsonConvert.SerializeObject(cart), new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
                }
                else
                {
                    cart = JsonConvert.DeserializeObject<Entities.ViewModels.Cart>(cookie);
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

        public CookiesCartStore(IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor = HttpContextAccessor;
            var user_identity = HttpContextAccessor.HttpContext.User.Identity;
            _CartName = $"cart{(user_identity.IsAuthenticated ? user_identity.Name : null)}";
        }
    }
}
