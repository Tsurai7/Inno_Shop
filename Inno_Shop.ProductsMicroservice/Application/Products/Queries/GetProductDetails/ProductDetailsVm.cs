using AutoMapper;
using Inno_Shop.Services.Products.Application.Common.Mappings;
using Inno_Shop.Services.Products.Domain.Models;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvaiable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Title,
                opt => opt.MapFrom(product => product.Title))
                .ForMember(productVm => productVm.Description,
                opt => opt.MapFrom(product => product.Description))
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.IsAvaiable,
                opt => opt.MapFrom(product => product.IsAvaiable))
                .ForMember(productVm => productVm.CreatedAt,
                opt => opt.MapFrom(product => product.CreatedAt))
                .ForMember(productVm => productVm.UpdatedAt,
                opt => opt.MapFrom(product => product.UpdatedAt));
        }
    }
}
