using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Request;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
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

        public List<Product> FindByFilter(Dictionary<string, int> page, Dictionary<string, string> filter)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                var queryable = dbContext.Product.AsQueryable();
                queryable = AddFiltersOnQuery(filter,queryable);
                var skip = (page[PaginationQueryParameters.PAGE_NUMBER] - 1) * page[PaginationQueryParameters.PAGE_SIZE];
                return queryable.Skip(skip).Take(page[PaginationQueryParameters.PAGE_SIZE]).ToList();
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

        public void Update(Product product)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Product.Update(product);
            }
        }

        private IQueryable<Product> AddFiltersOnQuery(Dictionary<string, string> filter, IQueryable<Product> queryable)
        {
            if (filter.ContainsKey("name") && !string.IsNullOrEmpty(filter["name"]))
            {
                queryable = queryable.Where(x => x.name.GetValue() == filter["name"]);
            }
            if (filter.ContainsKey("id") && !string.IsNullOrEmpty(filter["id"]))
            {
                queryable = queryable.Where(x => x.id.GetValue() == filter["id"]);
            }
            return queryable;
        }

    }
}
