using AutoMapper;
using Products.API.DbContexts;
using Products.API.Entities;
using Products.API.Interfaces;
using Products.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.API.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ProductDBContext _context;


        public CategoriesService(ProductDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<CategoryViewModel> GetAll()
        {
            var categories =  _context.Categories.ToList<Category>();

            var result = new List<CategoryViewModel>();
            foreach (var category in categories)
                result.Add(new CategoryViewModel { Name = category.Name });

            return result;
        }
    }
}
