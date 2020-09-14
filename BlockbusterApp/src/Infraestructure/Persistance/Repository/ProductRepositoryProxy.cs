using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Infraestructure.Service.Film;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Request;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using System.Collections.Generic;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class ProductRepositoryProxy : IProductRepository
    {
        private const string FILTER_NAME = "name";

        private IProductRepository productRepository;
        private FilmAdapter filmAdapter;
        private IUseCaseBus useCaseBus;

        public ProductRepositoryProxy(
            IProductRepository productRepository, 
            FilmAdapter filmAdapter, 
            IUseCaseBus useCaseBus)
        {
            this.productRepository = productRepository;
            this.filmAdapter = filmAdapter;
            this.useCaseBus = useCaseBus;
        }

        public void Add(Product product)
        {
            this.productRepository.Add(product);
        }

        public List<Product> FindByFilter(Dictionary<string, int> page, List<Filter> filters)
        {
            List<Domain.ProductAggregate.Product> products = this.productRepository.FindByFilter(page, filters);

            if (!ItShouldBeSearchedInExternalAPI(products,filters)) return products;

            Domain.ProductAggregate.Product product = this.filmAdapter.FindFilmFromName(GetFilterName(filters));
            if (product == null) return products;
            products.Add(product);
            this.useCaseBus.Dispatch(new CreateProductRequest(
                product.id.GetValue(),
                product.name.GetValue(),
                product.description.GetValue(),
                product.price.GetValue(),
                product.categoryId.GetValue()));

            return products;
        }

        private bool ItShouldBeSearchedInExternalAPI(List<Domain.ProductAggregate.Product> products, List<Filter> filters)
        {
            if (products.Count > 0) return false;
            if (!ExistFilterName(filters)) return false;
            return true;
        }

        private bool ExistFilterName(List<Filter> filters)
        {
            if (!filters.Any(f => f.property.Equals("name"))) return false;
            if (filters.Where(o => o.property.Equals("name")).FirstOrDefault().values.Length == 0) return false;
            return true;
        }

        private string GetFilterName(List<Filter> filters)
        {
            return filters.Where(f => f.property.Equals(FILTER_NAME)).FirstOrDefault().values[0];
        }


        public Product FindById(ProductId id)
        {
            return this.productRepository.FindById(id);
        }

        public Product FindByIdOrName(ProductId id, ProductName name)
        {
            return this.productRepository.FindByIdOrName(id, name);
        }

        public void Update(Product product)
        {
            this.productRepository.Update(product);
        }
    }
}
