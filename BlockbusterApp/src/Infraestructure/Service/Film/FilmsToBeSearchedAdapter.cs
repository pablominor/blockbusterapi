using System.Collections.Generic;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Service.Film
{
    public class FilmsToBeSearchedAdapter
    {

        public List<string> GetNamesFromFilmsThatShouldBeSearched(string[] filmNamesInFilter, List<Domain.ProductAggregate.Product> films)
        {
            List<string> filmNamesToBeSearched = new List<string>();
            foreach (string name in filmNamesInFilter)
            {
                if (films.Any(f => f.name.Equals(name))) continue;
                filmNamesToBeSearched.Add(name);
            }
            return filmNamesToBeSearched;
        }

    }
}
