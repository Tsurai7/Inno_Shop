using AutoMapper;
using Inno_Shop.Services.Products.Application.Common.Mappings;
using Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct;
using Inno_Shop.Services.Products.Application.Products.Commands.UpdateProduct;

namespace Inno_Shop.Services.Products.Application.Dto
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public string Description { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(productCommand => productCommand.Id,
                opt => opt.MapFrom(productDto => productDto.Id))
                .ForMember(productCommand => productCommand.Title,
                opt => opt.MapFrom(productDto => productDto.Title))
                .ForMember(productCommand => productCommand.Price,
                opt => opt.MapFrom(productDto => productDto.Price))
                .ForMember(productCommand => productCommand.IsAvailable,
                opt => opt.MapFrom(productDto => productDto.IsAvailable))
                .ForMember(productCommand => productCommand.Description,
                opt => opt.MapFrom(productDto => productDto.Description));
        }
    }
}
