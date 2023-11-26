

namespace Inno_Shop.Services.Products.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductService _productService;

        public ProductsController(IRepository<Product> repository, IProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                await _repository.AddAsync(product);
                await _repository.SaveAsync();
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
            try
            {
                var productFromDb = await _repository.GetByTitleAsync(product.Title);

                if (productFromDb == null)
                    return NotFound(product.Id);

                productFromDb.Title = product.Title;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price; 
                productFromDb.IsAvaiable = product.IsAvaiable;
                productFromDb.UpdatedAt = DateTime.UtcNow;
                await _repository.SaveAsync();
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
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] ProductFilterParameters filterParameters)
        {
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
