using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDrink.Model
{
    public class CupCounter
    {
        public int Count { get; set; }
        public DateOnly Date { get; set; }

        public string Rating { get; set; }

        public CupCounter(int count, DateOnly date)
        {
            Count = count;
            Date = date;
            Rating = Count switch
            {
                >= 8 => "👍",
                _ => "👎"
            };
        }
    }
}
