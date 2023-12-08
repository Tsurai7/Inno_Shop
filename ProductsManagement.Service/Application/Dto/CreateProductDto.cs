using AutoMapper;
using Inno_Shop.Services.Products.Application.Common.Mappings;
using Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct;

namespace Inno_Shop.Services.Products.Application.Dto
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool isAvailable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productCommand => productCommand.Title,
                opt => opt.MapFrom(productDto => productDto.Title))
                .ForMember(productCommand => productCommand.Description,
                opt => opt.MapFrom(productDto => productDto.Description))
                .ForMember(productCommand => productCommand.Price,
                opt => opt.MapFrom(productDto => productDto.Price))
                .ForMember(productCommand => productCommand.IsAvaiable,
                opt => opt.MapFrom(productDto => productDto.isAvailable));
        }
    }
}
