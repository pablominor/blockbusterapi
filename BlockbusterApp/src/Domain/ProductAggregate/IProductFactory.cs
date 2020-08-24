namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public interface IProductFactory
    {
        Product Create(string id, string name, string description, decimal price, string categoryId);
    }
}
