using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrinkDrink.ViewModel
{
    [QueryProperty("Cups", "Cups")]
    public partial class DrinkDetailsViewModel: BaseViewModel
    {
        [ObservableProperty]
        List<Cup> cups;
    }
}
