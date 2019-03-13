using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
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
    }
}
