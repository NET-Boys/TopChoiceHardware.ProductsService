using AutoMapper;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.ProductsService
{
    public class MappingProfile : Profile
    {
        /*private ICategoryRepository _categoryRepository;
        private ISupplierRepository _supplierRepository;
        public MappingProfile(ICategoryRepository categoryRepository, ISupplierRepository supplierRepository)
        {
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }*/
        public MappingProfile()
        {
            CreateMap<ProductDtoForCreation, Product>();
            CreateMap<Product, ProductDtoForDisplay>();
            CreateMap<Category, CategoryDto>();
            //.ForMember(dto => dto.CategoryName, act => act.MapFrom(src => _categoryRepository.GetCategoryById(src.CategoryId).CategoryName))
            //.ForMember(dto => dto.SupplierName, act => act.MapFrom(src => _supplierRepository.GetSupplierById(src.SupplierId).CompanyName));
        }
    }
}
