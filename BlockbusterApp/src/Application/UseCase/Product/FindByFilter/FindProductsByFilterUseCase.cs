using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;

namespace BlockbusterApp.src.Application.UseCase.Product.FindByFilter
{
    public class FindProductsByFilterUseCase : IUseCase
    {
        private IProductRepository productRepository;
        private FindProductsByFilterConverter converter;

        public FindProductsByFilterUseCase(IProductRepository productRepository, FindProductsByFilterConverter converter)
        {
            this.productRepository = productRepository;
            this.converter = converter;
        }

        public IResponse Execute(IRequest req)
        {
            FindProductsByFilterRequest request = req as FindProductsByFilterRequest;

            var products = this.productRepository.FindByFilter(request.Page(),request.Filter());

            return this.converter.Convert(products);
        }
    }
}
