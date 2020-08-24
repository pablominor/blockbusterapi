namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product FindById(ProductId id);
        Product FindByIdOrName(ProductId id,ProductName name);
    }
}
