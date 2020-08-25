using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Bus.UseCase.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Product.Response
{
    public class FindProductResponseConverter : ResponseConverter
    {
        public FindProductResponseConverter() { }

        public virtual IResponse Convert(dynamic item)
        {
            Domain.ProductAggregate.Product product = item as Domain.ProductAggregate.Product;

            string id = product.id.GetValue();
            string name = product.name.GetValue();
            string description = product.description.GetValue();
            decimal price = product.price.GetValue();
            string categoryId = product.categoryId.GetValue();
            FindProductResponse response = new FindProductResponse
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };

            return response;
        }
    }
}
