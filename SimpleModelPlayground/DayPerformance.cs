using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleModelPlayground
{
    public class DayPerformance
    {
        public DateOnly Date { get; set; }
        public List<Cup> Cups { get; set; }

        public DayPerformance()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            Cups = new List<Cup>();
        }
    }
}
