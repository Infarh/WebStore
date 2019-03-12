using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Entities.DTO;
using WebStore.Entities.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Tests
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void ProductDetails_Returns_View_With_Correct_Item()
        {
            const int expected_product_id = 10;
            const string expected_product_name = "Product name";
            const int expected_order = 1;
            const decimal expected_price = 10;
            const string expected_image_url = "image.jpg";
            const int expected_brand_id = 1;
            const string expected_brand_name = "Brand name";

            var product_data_mock = new Mock<IProductData>();
            product_data_mock
                .Setup(p => p.GetProductById(It.IsAny<int>()))
                .Returns<int>(id => new ProductDTO
                {
                    Id = id,
                    Name = expected_product_name,
                    Order = expected_order,
                    Price = expected_price,
                    ImageUrl = expected_image_url,
                    Brand = new BrandDTO
                    {
                        Id = expected_brand_id,
                        Name = expected_brand_name
                    }
                });

            var catalog_controller = new CatalogController(product_data_mock.Object);


            var result = catalog_controller.ProductDetails(expected_product_id);

            var view_result = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<ProductViewModel>(view_result.ViewData.Model);

            Xunit.Assert.Equal(expected_product_id, model.Id);
            Xunit.Assert.Equal(expected_product_name, model.Name);
            Xunit.Assert.Equal(expected_order, model.Order);
            Xunit.Assert.Equal(expected_price, model.Price);
            Xunit.Assert.Equal(expected_image_url, model.ImageUrl);
            Xunit.Assert.Equal(expected_brand_name, model.Brand);
        }
                                         
        [TestMethod]
        public void ProductDetails_Returns_NotFound()
        {
            var products_data_mock = new Mock<IProductData>();
            products_data_mock
                .Setup(p => p.GetProductById(It.IsAny<int>()))
                .Returns((ProductDTO)null);

            var catalog_controller = new CatalogController(products_data_mock.Object);

            var result = catalog_controller.ProductDetails(1);
            Xunit.Assert.IsType<NotFoundResult>(result);
        }
    }
}
