using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly IServiceScopeFactory scopeFactory;

        public CategoryRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }

        public void Add(Category category)
        {
            using(var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Category.Add(category);                
            }
        }

        public Category FindById(CategoryId id)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Category.FirstOrDefault(c => c.id.GetValue() == id.GetValue());
            }
        }

        public Category FindByIdOrName(CategoryId id,CategoryName name)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Category.FirstOrDefault(c => c.id.GetValue() == id.GetValue() || c.name.GetValue() == name.GetValue());
            }
        }
    }
}
