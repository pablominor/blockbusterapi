using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Product.Create
{
    public class CreateProductUseCase : IUseCase
    {
        private IProductFactory productFactory;
        private IProductRepository productRepository;
        private EmptyResponseConverter converter;
        private CreateProductValidator validator;

        public CreateProductUseCase(
            IProductFactory productFactory,
            IProductRepository productRepository,
            EmptyResponseConverter converter,
            CreateProductValidator validator)
        {
            this.productFactory = productFactory;
            this.productRepository = productRepository;
            this.converter = converter;
            this.validator = validator;
        }

        public IResponse Execute(IRequest req)
        {
            CreateProductRequest request = req as CreateProductRequest;

            Domain.ProductAggregate.Product product = productFactory.Create(request.Id, request.Name,request.Description,request.Price,request.CategoryId);

            this.validator.Validate(product.id, product.name);

            this.productRepository.Add(product);

            return this.converter.Convert();
        }
    }
}
