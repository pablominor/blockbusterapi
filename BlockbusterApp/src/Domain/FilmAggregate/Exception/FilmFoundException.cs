using BlockbusterApp.src.Shared.Domain.Exception;
using System;

namespace BlockbusterApp.src.Domain.FilmAggregate.Exception
{
    public class FilmFoundException : ValidationException
    {
        public FilmFoundException(string value) : base(value) { }

        public static FilmFoundException FromId(FilmId id)
        {
            return new FilmFoundException(String.Format("Film is already register with the id {0}.", id.GetValue()));
        }

        public static FilmFoundException FromName(FilmName name)
        {
            return new FilmFoundException(String.Format("Film is already register with the name {0}.", name.GetValue()));
        }
    }
}
