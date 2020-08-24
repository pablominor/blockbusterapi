namespace BlockbusterApp.src.Domain.ProductAggregate.Service
{
    public class ProductValueObjectsFactory
    {
        public static ProductId CreateProductId(string id)
        {
            return new ProductId(id);
        }

        public static ProductName CreateProductName(string name)
        {
            return new ProductName(name);
        }

        public static ProductDescription CreateProductDescription(string description)
        {
            return new ProductDescription(description);
        }

        public static ProductPrice CreateProductPrice(decimal price)
        {
            return new ProductPrice(price);
        }

        public static ProductCategoryId CreateProductCategoryId(string categoryId)
        {
            return new ProductCategoryId(categoryId);
        }       

    }
}
