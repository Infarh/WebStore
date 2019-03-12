using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Interfaces.Api;

namespace WebStore.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _HomeController;

        [TestInitialize]
        public void StartupTest()
        {
            var values_sevice = new Mock<IValuesService>();
            values_sevice.Setup(values => values.GetAsync()).ReturnsAsync(new[] { "1", "2" });

            _HomeController = new HomeController(values_sevice.Object);
        }

        [TestMethod]
        public async Task WebApiTest_Method_Returns_View_With_Two_String_Values()
        {
            var view = await _HomeController.WebApiTest();

            var view_result = Xunit.Assert.IsType<ViewResult>(view);

            var model = Xunit.Assert.IsAssignableFrom<IEnumerable<string>>(view_result.ViewData.Model);

            Xunit.Assert.Equal(2, model.Count());
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            var view = _HomeController.Index();
            Xunit.Assert.IsType<ViewResult>(view);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var view = _HomeController.ContactUs();
            Xunit.Assert.IsType<ViewResult>(view);
        }

        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            var view = _HomeController.BlogSingle();
            Xunit.Assert.IsType<ViewResult>(view);
        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            var view = _HomeController.Blog();
            Xunit.Assert.IsType<ViewResult>(view);
        }

        [TestMethod]
        public void NotFoundPage_Returns_View()
        {
            var view = _HomeController.NotFoundPage();
            Xunit.Assert.IsType<ViewResult>(view);
        }

        [TestMethod]
        public void ErrorStatus_404_Return_Redirect2NotFound()
        {
            var result = _HomeController.ErrorStatus("404");
            var redirect_to_action_result = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.NotNull(redirect_to_action_result);
            Xunit.Assert.Equal(nameof(HomeController.NotFoundPage), redirect_to_action_result.ActionName);
        }

    }
}
