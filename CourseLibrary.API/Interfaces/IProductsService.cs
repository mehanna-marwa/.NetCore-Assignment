using Products.API.Models.ActionModels;
using Products.API.Models.ViewModels;
using System.Collections.Generic;

namespace Products.API.Interfaces
{
    public interface IProductsService
    {
        List<ProductViewModel> GetAll();

        ProductViewModel GetProductById(int id);

        (bool, ProductViewModel) AddProduct(SaveProductActionModel model);
        (bool, ProductViewModel) UpdateProduct(UpdateProductViewModel model);

        bool DeleteProduct(int id);
    }
}
