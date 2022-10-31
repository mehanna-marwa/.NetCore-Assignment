using Products.API.Models.ViewModels;
using System.Collections.Generic;

namespace Products.API.Interfaces
{
    public interface ICategoriesService
    {
        List<CategoryViewModel> GetAll();
    }
}
