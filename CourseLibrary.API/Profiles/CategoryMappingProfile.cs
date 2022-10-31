using AutoMapper;
using Products.API.Entities;
using Products.API.Models.ViewModels;

namespace Products.API.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
