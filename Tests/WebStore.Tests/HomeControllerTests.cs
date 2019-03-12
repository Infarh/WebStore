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
    }
}
