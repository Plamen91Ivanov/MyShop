using Shop.Services.Mapping;
namespace Shop.Web.ViewModels.Brand
{
    public class BrandViewModel : IMapFrom<Shop.Data.Models.Brand>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Logo { get; set; }
    }
}
