using AutoMapper;
using Inno_Shop.Services.Products.Application.Common.Mappings;
using Inno_Shop.Services.Products.Domain.Models;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductList
{
    public class ProductLookUpDto : IMapWith<Product>
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvaiable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookUpDto>()
                .ForMember(productDto => productDto.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Title,
                opt => opt.MapFrom(product => product.Title))
                .ForMember(productDto => productDto.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.IsAvaiable,
                opt => opt.MapFrom(product => product.IsAvaiable));
        }
    }
}
