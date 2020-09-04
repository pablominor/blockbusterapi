using BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI.Exception;
using System.Collections.Generic;
using System.Linq;

namespace BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI
{
    public class CraftCodeAPIFilmDeserializer
    {
        public CraftCodeFilm FromJSONToCrafCodeFilm(string json, string name)
        {
            List<CraftCodeFilm> craftCodeFilms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CraftCodeFilm>>(json);

            if(craftCodeFilms.Count() == 0)
            {
                throw CraftCodeAPIFilmNotFoundException.FromName(name);
            }

            return craftCodeFilms[0];
        }


    }
}
