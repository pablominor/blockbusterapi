using BlockbusterApp.src.Domain.ProductAggregate.Exception;

namespace BlockbusterApp.src.Domain.ProductAggregate.Service
{
    public class CreateProductValidator
    {
        private IProductRepository productRepository;
        public CreateProductValidator(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public virtual void Validate(ProductId id, ProductName name)
        {
            ItShouldNotExistsCategoryWithIdOrName(id, name);
        }

        private void ItShouldNotExistsCategoryWithIdOrName(ProductId id, ProductName name)
        {
            Domain.ProductAggregate.Product product = this.productRepository.FindByIdOrName(id, name);
            if (product != null && product.id.Equals(id))
            {
                throw ProductFoundException.FromId(id);
            }
            if (product != null && product.name.Equals(name))
            {
                throw ProductFoundException.FromName(name);
            }
        }
    }
}
