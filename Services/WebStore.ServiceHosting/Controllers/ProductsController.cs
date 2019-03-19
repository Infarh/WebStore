﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.DTO;
using WebStore.Entities.DTO.Product;
using WebStore.Entities.Entries;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class ProductsController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData) => _ProductData = ProductData;

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections() => _ProductData.GetSections();

        [HttpGet("sections/{id}")]
        public Section GetSectionById(int id) => _ProductData.GetSectionById(id);

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands() => _ProductData.GetBrands();

        [HttpGet("brands/{id}")]
        public Brand GetBrandById(int id) => _ProductData.GetBrandById(id);

        [HttpPost, ActionName("Post")]
        public PagedProductDTO GetProducts([FromBody] ProductFilter Filter) => _ProductData.GetProducts(Filter);

        [HttpGet("{id}"), ActionName("Get")]
        public ProductDTO GetProductById(int id) => _ProductData.GetProductById(id);
    }
}