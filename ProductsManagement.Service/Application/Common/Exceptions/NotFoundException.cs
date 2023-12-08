namespace Inno_Shop.Services.Products.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) 
            : base($"Entity\"{name}\" ({key}) not found.") { }
    }
}
