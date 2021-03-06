﻿using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Entities.DTO.Order;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;

namespace WebStore.Tests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void CheckOut_ModelState_Invalid_Returns_ViewModel()
        {
            var cart_sertvice_mock = new Mock<ICartService>();
            var order_Service_mock = new Mock<IOrderService>();

            var controller = new CartController(cart_sertvice_mock.Object, order_Service_mock.Object);

            controller.ModelState.AddModelError("error", "InvalidModel");

            const string expected_name = "Test";
            var result = controller.CheckOut(new OrderViewModel { Name = expected_name });
            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<DetailsViewModel>(view_result.ViewData.Model);

            Assert.Equal(expected_name, model.Order.Name);
        }

        [TestMethod]
        public void CheckOut_Calls_Service_And_Return_Redirect()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "UserName") }));

            var cart_service_mock = new Mock<ICartService>();
            cart_service_mock
                .Setup(c => c.TransformCart())
                .Returns(new CartViewModel
                {
                    Items = new Dictionary<ProductViewModel, int>
                    {
                        { new ProductViewModel(), 1 }
                    }
                });

            var orders_servce_mock = new Mock<IOrderService>();
            orders_servce_mock
                .Setup(o => o.CreateOrder(It.IsAny<CreateOrderModel>(), It.IsAny<string>()))
                .Returns<CreateOrderModel, string>((m, s) => new OrderDTO { Id = 1 });

            var controller = new CartController(cart_service_mock.Object, orders_servce_mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };

            var order_view_model = new OrderViewModel
            {
                Name = "test",
                Address = "address",
                Phone = "+7(123)456-78-90"
            };
            var result = controller.CheckOut(order_view_model);

            var redirect_result = Assert.IsType<RedirectToActionResult>(result);

            Assert.Null(redirect_result.ControllerName);
            Assert.Equal(nameof(CartController.OrderConfirmed), redirect_result.ActionName);
            Assert.Equal(1, redirect_result.RouteValues["id"]);
        }
    }
}
