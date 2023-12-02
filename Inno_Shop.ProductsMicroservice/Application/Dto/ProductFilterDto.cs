namespace Inno_Shop.Services.Products.Application.Dto
{
    public class ProductFilterDto
    {
        public string? Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsAvaiable { get; set; }
        public DateTime? CreatedAtStart { get; set; }
        public DateTime? CreatedAtEnd { get; set; }
    }
}
