using Restaurant_Demonstration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.Data
{
    public interface ICustomersDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }

    public class CustomersDataProvider : ICustomersDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work, it needs the DB Info

            return new List<Customer>
          {
            new Customer{CustomerId=1,FirstName="Julia",LastName="Developer",ReservationDate = 01.20, Ordered=true},
            new Customer{CustomerId=2,FirstName="Alex",LastName="Rider"},
            new Customer{CustomerId=3, FirstName="Thomas",LastName="Huber",ReservationDate = 03.30, Ordered=true},
            new Customer{CustomerId=4,FirstName="Anna",LastName="Rockstar"},
            new Customer{CustomerId=5,FirstName="Sara",LastName="Metroid"},
            new Customer{CustomerId=6,FirstName="Ben",LastName="Ronaldo"}
          };
        }
    }
}
