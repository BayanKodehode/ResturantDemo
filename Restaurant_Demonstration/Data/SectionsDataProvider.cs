using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.Data
{
    public interface ISectionsDataProvider 
    {
        Task<IEnumerable<Section>?> GetAllAsync();
       
        public class SectionsDataProvider : ISectionsDataProvider
        {
            public async Task<IEnumerable<Section>?> GetAllAsync()
            {
                await Task.Delay(100); // Simulate a bit of server work

                return new List<Section>
                {
                    new Section{SectionId=1,
                        SectionName = "Section 1", 
                        SectionTables = 2},
                    new Section{SectionId=2,
                        SectionName = "Section 2", 
                        SectionTables = 1},
                    new Section{SectionId=3,
                        SectionName = "Section 3", 
                        SectionTables = 4},
                };
            }
        }
    }
}