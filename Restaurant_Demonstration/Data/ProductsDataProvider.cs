using Restaurant_Demonstration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.Data
{
    public interface IProductsDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }
    public class ProductsDataProvider : IProductsDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work

            return new List<Product>
            {
            new Product{Name="Cappuccino",Description="Espresso with milk and milk foam"},
            new Product{Name="Doppio",Description="Double espresso"},
            new Product{Name="Espresso",Description="Pure coffee to keep you awake! :-)"},
            new Product{Name="Latte",Description="Cappuccino with more streamed milk"},
            new Product{Name="Macchiato",Description="Espresso with milk foam"},
            new Product{Name="Mocha",Description="Espresso with hot chocolate and milk foam"}
            };
        }
    }
}
