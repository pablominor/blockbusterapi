

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL.Entity
{
    public class UrlHelper
    {
        public string self { get; }
        public string type { get; }
  
        private UrlHelper(
            string self,
            string type)
        {
            this.self = self;
            this.type = type;            
        }


        public static UrlHelper Create(
            string self,
            string type)
        {
            return new UrlHelper(self, type);
        }
    }
}
