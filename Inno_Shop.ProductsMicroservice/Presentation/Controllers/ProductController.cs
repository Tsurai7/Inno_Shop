

using Inno_Shop.Services.Products.Presentation.Validators;

namespace Inno_Shop.Services.Products.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IRepository<Product> repository, IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var validator = new ProductValidator();
            var validationResult = await validator.ValidateAsync(product);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                await _productService.AddAsync(product);
                return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            var validator = new ProductValidator();
            var validationResult = await validator.ValidateAsync(product);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                var productFromDb = await _productService.GetByTitleAsync(product.Title);

                if (productFromDb == null)
                    return NotFound(product.Id);

                productFromDb.Title = product.Title;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price; 
                productFromDb.IsAvaiable = product.IsAvaiable;
                productFromDb.UpdatedAt = DateTime.UtcNow;
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteAsync(id);

            return NoContent();
        }


        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] ProductFilterDto filterParameters)
        {
            var validator = new ProductFilterDtoValidator();
            var validationResult = await validator.ValidateAsync(filterParameters);

            if (!validationResult.IsValid)            
                return BadRequest(validationResult.Errors);
            

            try
            {
                var filteredProducts = await _productService.GetFilteredAsync(filterParameters);
                return Ok(filteredProducts);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
