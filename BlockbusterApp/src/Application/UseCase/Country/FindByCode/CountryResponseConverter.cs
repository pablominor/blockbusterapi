using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Country.FindByCode
{
    public class CountryResponseConverter : ResponseConverter
    {

        public CountryResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.CountryAggregate.Country country = item as Domain.CountryAggregate.Country;            
            return new CountryResponse(country);
        }
    }
}
