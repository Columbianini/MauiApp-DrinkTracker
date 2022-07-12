using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrinkDrink.ViewModel
{
    [QueryProperty("Counter", "Counter")]
    public partial class DrinkDetailsViewModel: BaseViewModel
    {
        [ObservableProperty]
        CupCounter counter;
    }
}
