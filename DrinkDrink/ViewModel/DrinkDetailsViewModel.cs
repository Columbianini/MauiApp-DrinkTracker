using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrinkDrink.ViewModel
{
    [QueryProperty("Cups", "Cups")]
    [QueryProperty("TotalDrinkSecondsSeries", "TotalDrinkSecondsSeries")]
    public partial class DrinkDetailsViewModel: BaseViewModel
    {
        [ObservableProperty]
        List<Cup> cups;
        [ObservableProperty]
        ISeries[] totalDrinkSecondsSeries;
    }
}

// TODO:
// 1. Add TotalDrinkSeconds List at TodayDrinkViewModel at Line 158
// 2. Add Another Query Property [QueryProperty("TotalDrinkSeconds", "TotalDrinkSeconds")]
// 3. Add totalDrinkSeconds as a ObservableProperty at line 15 in the file
// 4. Update DrinkPage to show totaldrinkseconds
// 5. Check  to add step line plot, if no data gives none https://lvcharts.com/docs/maui/2.0.0-beta.300/CartesianChart.Cartesian%20chart%20control
