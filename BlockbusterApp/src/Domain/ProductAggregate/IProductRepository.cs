using System.Collections.Generic;

namespace BlockbusterApp.src.Domain.ProductAggregate
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product FindById(ProductId id);
        Product FindByIdOrName(ProductId id,ProductName name);
        void Update(Product product);
        List<Product> FindByFilter(Dictionary<string, int> page, Dictionary<string, string> filter);
    }
}
