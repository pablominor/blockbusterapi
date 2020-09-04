using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI
{
    public class CraftCodeAPIFilmFacade : IFilmFacade
    {
        private CraftCodeAPIFilmCaller craftCodeAPIFilmCallerCaller;
        private CraftCodeAPIFilmDeserializer craftCodeAPIFilmDeserializer;

        public CraftCodeAPIFilmFacade(CraftCodeAPIFilmCaller craftCodeAPIFilmCallerCaller, CraftCodeAPIFilmDeserializer craftCodeAPIFilmDeserializer)
        {
            this.craftCodeAPIFilmCallerCaller = craftCodeAPIFilmCallerCaller;
            this.craftCodeAPIFilmDeserializer = craftCodeAPIFilmDeserializer;
        }

        public object FindFilmFromName(string name)
        {
            string json = this.craftCodeAPIFilmCallerCaller.GetJSONResponse(name);

            CraftCodeFilm craftCodeFilm = this.craftCodeAPIFilmDeserializer.FromJSONToCrafCodeFilm(json, name);            

            return craftCodeFilm;
        }
    }
}
