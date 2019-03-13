using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStore.Entities.ViewModels;
using Assert = Xunit.Assert;

namespace WebStore.Services.Tests
{
    [TestClass]
    public class CartServiceTests
    {
        [TestMethod]
        public void CartClass_ItemsCount_Returns_Correct_Quantity()
        {
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                  new CartItem
                  {
                        ProductId = 1,
                        Quantity = 1
                  },
                  new CartItem
                  {
                      ProductId = 3,
                      Quantity = 3
                  }
                }
            };
            const int expected_count = 4;

            var actual_count = cart.ItemsCount;

            Assert.Equal(expected_count, actual_count);
        }

        [TestMethod]
        public void CartViewModel_Retulrns_Correct_ItemsCOunt()
        {
            var cart_view_model = new CartViewModel
            {
                Items = new Dictionary<ProductViewModel, int>
                {
                    { new ProductViewModel { Id = 1, Name = "Item1", Price = 5m }, 1 },
                    { new ProductViewModel { Id = 2, Name = "Item2", Price = 10m }, 2 },
                }
            };
            const int expected_items_count = 3;

            var actual_items_count = cart_view_model.ItemsCount;

            Assert.Equal(expected_items_count, actual_items_count);
        }
    }
}
