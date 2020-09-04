using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Infraestructure.Service.Film.CraftCodeAPI.Exception
{
    public class CraftCodeAPIFilmNotFoundException : ValidationException
    {
        public CraftCodeAPIFilmNotFoundException(string value) : base(value) { }

        public static CraftCodeAPIFilmNotFoundException FromName(string name)
        {
            return new CraftCodeAPIFilmNotFoundException(String.Format("Film with name {0} doesn't exists.", name));
        }
    }
}
