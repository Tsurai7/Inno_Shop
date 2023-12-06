using AutoMapper;
using Inno_Shop.Services.Products.Application.Dto;
using Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct;
using Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct;
using Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails;
using Inno_Shop.Services.Products.Application.Products.Queries.GetProductList;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.Services.Products.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper) =>      
            _mapper = mapper;
        

        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVm>> GetById(long id)
        {
            var query = new GetProductDetailsQuery
            {
                UserId = UserId,
                Id = id
            };


            var vm = await Mediator.Send(query);     

            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);

            command.UserId = UserId;

            var noteId = await Mediator.Send(command);
            
            return Ok(noteId);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var command = _mapper.Map<UpdateProductDto>(updateProductDto);

            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteProductCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
