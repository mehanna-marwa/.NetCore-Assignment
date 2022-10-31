using Products.API.DbContexts;
using Products.API.Entities;
using Products.API.Interfaces;
using Products.API.Models.ActionModels;
using Products.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.API.Services
{
    public class ProductsService : IProductsService, IDisposable
    {
        private readonly ProductDBContext _context;


        public ProductsService(ProductDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public List<ProductViewModel> GetAll()
        {
            var products = _context.Products.ToList<Product>();

            var result = new List<ProductViewModel>();
            foreach (var product in products)
            {
                result.Add(new ProductViewModel { Name = product.Name, Id = product.Id, Price = product.Price,
                    ImgURL = product.ImgURL, Quantity = product.Quantity, CategoryName = _context.Categories.FirstOrDefault(a => a.Id == product.CateogryID)!.Name
                });

            }

            return result;
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == id);

            if (product == null)
                return null;
            else
            {
                return new ProductViewModel
                {
                    Name = product.Name,
                    Id = product.Id,
                    Price = product.Price,
                    ImgURL = product.ImgURL,
                    Quantity = product.Quantity,
                    CategoryName = _context.Categories.FirstOrDefault(a => a.Id == product.CateogryID)!.Name
                };
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }

        public (bool, ProductViewModel) AddProduct(SaveProductActionModel model)
        {
            if (model == null)
                return (false, null);

            else
            {
                var saved = _context.Products.Add(new Product()
                {
                    CateogryID = model.CategoryId,
                    ImgURL = model.ImgURL,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Name = model.Name
                });
                _context.SaveChanges();



                return (true, new ProductViewModel() { Id =  saved.Entity.Id,
                    Name = saved.Entity.Name,
                    Price = saved.Entity.Price,
                    ImgURL = saved.Entity.ImgURL,
                    Quantity = saved.Entity.Quantity,
                    CategoryName = _context.Categories.FirstOrDefault(a => a.Id == saved.Entity.CateogryID)!.Name
                });
            }
        }

        public (bool, ProductViewModel) UpdateProduct(UpdateProductViewModel model)
        {
            if (model == null)
                return (false, null);

            else
            {
                var existingProduct = _context.Products.FirstOrDefault(a=> a.Id == model.Id);

                existingProduct.Price = model.Price;
                existingProduct.Quantity = model.Quantity;
                existingProduct.Name = model.Name;
                existingProduct.CateogryID = model.CategoryId;
                existingProduct.ImgURL = model.ImgURL;

                _context.Update(existingProduct);
                _context.SaveChanges();

                return (true, new ProductViewModel()
                {
                    Id = existingProduct.Id,
                    Name = existingProduct.Name,
                    Price = existingProduct.Price,
                    ImgURL = existingProduct.ImgURL,
                    Quantity = existingProduct.Quantity,
                    CategoryName = _context.Categories.FirstOrDefault(a => a.Id == existingProduct.CateogryID)!.Name
                });
            }
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(b=>b.Id == id);

            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
