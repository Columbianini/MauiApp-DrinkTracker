using DrinkDrink.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDrink.ViewModel
{
    public partial class TodayDrinkViewModel: BaseViewModel
    {
        Cup currentCup;
        DrinkIOService drinkIOService;

        public ObservableCollection<CupCounter> CupCounters { get; set; } = new();
        public ObservableCollection<Cup> Cups { get; set; } = new();

        [ObservableProperty]
        public int numberOfCups;

        [ObservableProperty]
        public int cupOnHand;


        public TodayDrinkViewModel(DrinkIOService drinkIOService)
        {
            this.drinkIOService = drinkIOService;
            CupOnHand = 0;
            NumberOfCups = 0;
        }

        [RelayCommand]
        void StartDrink()
        {
            currentCup = new Cup();
            CupOnHand = 1;
        }


        [RelayCommand]
        async Task FinishDrinkAsync()
        {
            if (IsBusy)
                return;
            if (CupOnHand == 0)
            {
                await Shell.Current.DisplayAlert("Warning", "Cheating! You should fill your bottle first", "ok");
                return;
            }
            try
            {  
                currentCup.FinishDrinkTime = DateTime.Now;
                Cups.Add(currentCup);
                await drinkIOService.WriteCupsToFileAsync(Cups.ToList());
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Error When Saving, Errors: {ex.Message}", "ok");
                throw;
            }
            finally
            {
                IsBusy = false;
                CupOnHand = 0;
                NumberOfCups = Cups.Count;
            }
            
        }

        [RelayCommand]
        async Task GetAllHistoryAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var cups = await drinkIOService.GetCupsFromFileAsync();
                if (Cups.Count != 0)
                    Cups.Clear();
                foreach(var cup in cups)
                    Cups.Add(cup);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Error Happens when reading the cache file. Details: {ex.Message}", "ok");
                throw;
            }
            finally
            {
                IsBusy = false;
                CupOnHand = 0;
                NumberOfCups = Cups.Count;
            }   
        }

        [RelayCommand]
        async Task GetHistoricalSummaryAsync()
        {
            if (CupCounters.Count > 0)
            {
                CupCounters.Clear();
            }
            try
            {
                if (Cups.Count == 0)
                {
                    await GetAllHistoryAsync();
                }
                var cupCounters = Cups.
                    OrderBy(s => s.StartDrinkTime.Date).
                    GroupBy(s => s.StartDrinkTime.Date).
                    Select(grp => new CupCounter(grp.Count(), DateOnly.FromDateTime(grp.Key)));
                foreach(var counter in cupCounters)
                {
                    CupCounters.Add(counter);
                }
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error!", $"Error Happens when reading the cache file. Details: {ex.Message}", "ok");
                throw;
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(CupCounter counter)
        {
            if (counter is null)
                return;

            List<Cup> cups = Cups.
                Where(cup => counter.Date == DateOnly.FromDateTime(cup.StartDrinkTime)).
                Select(cup => new Cup() { StartDrinkTime = cup.StartDrinkTime, FinishDrinkTime = cup.FinishDrinkTime }).ToList();
            int i = 1;
            foreach (var cup in cups)
            {
                cup.Id = i;
                i++;
            }


            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Cups", cups }
            });
        }

    }
}
