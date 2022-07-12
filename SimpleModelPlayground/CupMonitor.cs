using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleModelPlayground
{
    public class CupMonitor
    {
        List<Cup> cups;
        Cup? currentCup = null;
        DrinkIOService drinkIOService;

        public string State { 
            get
            {
                List<string> state = new()
                {
                    $"You have already drunk {cups.Count} cups of water",
                    $"You have {(currentCup is null ? 0 : 1)} cup of water on hand"
                };
                return string.Join(Environment.NewLine, state);
            } 
        }

        public string Details
        {
            get
            {
                if (cups.Count > 0)
                    return string.Join(Environment.NewLine, cups);
                else
                    return "You have not drunk any water today";
            }
        }


        public CupMonitor()
        {
            cups = new List<Cup>();
            drinkIOService = new DrinkIOService();
        }
        
        public void StartDrink()
        {
            currentCup = new Cup();
        }


        public void FinishDrink()
        {
            //if (!cup.IsFinished)
            //{
            //    Console.WriteLine("Please finish your drink first");
            //    return;
            //}
            if(currentCup is null)
            {
                Console.WriteLine("You should first start to drink");
                return;
            }
            currentCup.FinishDrinkTime = DateTime.Now;
            cups.Add(currentCup);
            drinkIOService.WriteCupsToFile(cups);
            currentCup = null;
        }

        public void GetAllHistory()
        {
            if (cups.Count > 0)
                cups.Clear();
            cups = drinkIOService.GetCupsFromFile();
        }
    }
}
