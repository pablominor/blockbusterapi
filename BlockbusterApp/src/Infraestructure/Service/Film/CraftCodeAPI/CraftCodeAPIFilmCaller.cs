using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI
{
    public class CraftCodeAPIFilmCaller
    {

        private const string API_URL = "http://api.movie.craft-code.com:9333/movies?title=";

        public string GetJSONResponse(string name)
        {
            WebRequest request = HttpWebRequest.Create(API_URL + name);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            return json;            
        }
    }
}
