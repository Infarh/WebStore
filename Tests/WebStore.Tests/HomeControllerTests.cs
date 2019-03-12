using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            values_sevice.Setup(values => values.GetAsync()).ReturnsAsync(new [] {"1", "2", "3"});

            _HomeController = new HomeController(values_sevice.Object);
        }
    }
}
