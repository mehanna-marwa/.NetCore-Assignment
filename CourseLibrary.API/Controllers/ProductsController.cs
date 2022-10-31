using Products.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.API.Interfaces;
using Products.API.Models;
using Products.API.Models.ActionModels;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsRepository;

        public ProductsController(IProductsService productsRepository)
        {
            _productsRepository = productsRepository ??
            throw new ArgumentNullException(nameof(productsRepository));

        }
        /*
GET: /products?categoryID={id}
POST: /products
PUT: /products/{id}
        */

        [HttpGet()]
        public ActionResult GetAll()
        {
            var data = _productsRepository.GetAll();

            return Ok(new ApiResponseModel(data));
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            var data = _productsRepository.GetProductById(id);

            return Ok(new ApiResponseModel(data));
        }

        [HttpPost()]
        public ActionResult AddPRoduct([FromBody] SaveProductActionModel model)
        {
            var (isAdded, data) = _productsRepository.AddProduct(model);

            return Ok(new ApiResponseModel(data, isAdded, null));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePRoduct([FromBody] UpdateProductViewModel model)
        {
            var (isAdded, data) = _productsRepository.UpdateProduct(model);

            return Ok(new ApiResponseModel(data, isAdded, null));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDomain(int id)
        {
            var isDeleted = _productsRepository.DeleteProduct(id);
            return Ok(new ApiResponseModel(null, isDeleted, null));
        }

    }
}
