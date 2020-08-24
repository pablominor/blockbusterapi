using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly IServiceScopeFactory scopeFactory;

        public ProductRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }


        public void Add(Product product)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Product.Add(product);
            }
        }

        public Product FindById(ProductId id)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Product.FirstOrDefault(c => c.id.GetValue() == id.GetValue());
            }
        }

        public Product FindByIdOrName(ProductId id,ProductName name)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Product.FirstOrDefault(c => c.id.GetValue() == id.GetValue() || c.name.GetValue() == name.GetValue());
            }
        }
    }
}
