using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly IServiceScopeFactory scopeFactory;

        public CountryRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }

        public Country FindCountryByCode(CountryCode code)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Country.FirstOrDefault(c => c.code.GetValue() == code.GetValue());
            }
        }
    }
}
