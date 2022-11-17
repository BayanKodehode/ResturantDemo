using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductsDataProvider _productsDataProvider;

        public ProductsViewModel(IProductsDataProvider productsDataProvider)
        {
            _productsDataProvider = productsDataProvider;
        }
        public ObservableCollection<Product> Products { get; } = new();
        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await _productsDataProvider.GetAllAsync();
            if (products is not null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
    }
}
