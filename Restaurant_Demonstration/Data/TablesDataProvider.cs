using Restaurant_Demonstration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.Data
{
    public interface ITablesDataProvider
        {
        Task<IEnumerable<Table>?> GetAllAsync();

            public class TablesDataProvider : ITablesDataProvider
            {
                public async Task<IEnumerable<Table>?> GetAllAsync()
                {
                    await Task.Delay(100); // Simulate a bit of server work

                    return new List<Table>
                {
                    new Table{TableId=1,
                        TableName = "table 1",
                        Avaliblity = true,
                        ReservationId = 1},
                    new Table{TableId=2,
                        TableName = "Table 2",
                        Avaliblity = true,
                        ReservationId = 2},
                    new Table{TableId= 3,
                        TableName = "Table 3",
                        Avaliblity = true,
                        ReservationId = 3 }
                };
                }
            }
        }
}
