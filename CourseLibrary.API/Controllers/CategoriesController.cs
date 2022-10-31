using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.API.Interfaces;
using Products.API.Models;
using System;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryRepository;


        public CategoriesController(ICategoriesService categoryRepository)
        {
            _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));

        }

        [HttpGet()]
        public ActionResult GetAll()
        {
            var data = _categoryRepository.GetAll();

            return Ok(new ApiResponseModel(data));
        }
    }
}
