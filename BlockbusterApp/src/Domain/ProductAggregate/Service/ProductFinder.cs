using BlockbusterApp.src.Domain.ProductAggregate.Exception;

namespace BlockbusterApp.src.Domain.ProductAggregate.Service
{
    public class ProductFinder
    {
        private IProductRepository productRepository;

        public ProductFinder(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public virtual Product FindOneById(ProductId productId)
        {
            var product = this.productRepository.FindById(productId);
            if (product == null)
            {
                throw ProductNotFoundException.FromId(productId);
            }
            return product;
        }
    }
}
