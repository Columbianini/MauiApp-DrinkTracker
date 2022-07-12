using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDrink.Model
{
    public class Cup
    {
        private bool isFinished;
        private DateTime finishedDrinkTime;
        public bool IsFinished { get { return isFinished; } set { isFinished = value; } }
        public DateTime StartDrinkTime { get; set; }
        public DateTime FinishDrinkTime
        {
            get { return finishedDrinkTime; }
            set
            {
                isFinished = true;
                finishedDrinkTime = value;
            }
        }

        public Cup()
        {
            isFinished = false;
            StartDrinkTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"You start to drink at {StartDrinkTime} and Finish your drink at {FinishDrinkTime}";
        }
    }
}
