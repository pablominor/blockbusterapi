using BlockbusterApp.src.Domain.FilmAggregate;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Persistance.Repository
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {

        private readonly IServiceScopeFactory scopeFactory;

        public FilmRepository(BlockbusterContext context, IServiceScopeFactory scopeFactory) : base(context)
        {
            this.scopeFactory = scopeFactory;
        }


        public void Add(Film film)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                dbContext.Film.Add(film);
            }
        }

        public Film FindById(FilmId id)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Film.FirstOrDefault(c => c.id.GetValue() == id.GetValue());
            }
        }

        public Film FindByName(FilmName name)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BlockbusterContext>();
                return dbContext.Film.FirstOrDefault(c => c.name.GetValue() == name.GetValue());
            }
        }
    }
}
