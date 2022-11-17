using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.Model
{
    public class Table
    {
        public int TableId { get; set; }
        public string? TableName { get; set; }
        public bool Avaliblity { get; set; }
        public int ReservationId { get; set; }

    }
}
