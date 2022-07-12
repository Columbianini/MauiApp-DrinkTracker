// See https://aka.ms/new-console-template for more information
using SimpleModelPlayground;

var monitor = new CupMonitor();
monitor.GetAllHistory();

while (true)
{
    monitor.GetAllHistory();
    Console.WriteLine(monitor.State);
    Console.WriteLine(monitor.Details);
    Console.WriteLine("What you want to do? ");
    Console.WriteLine("1. Fill Bottle");
    Console.WriteLine("2. Finish Drink");
    Console.WriteLine("3. Exit");
    if(int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                monitor.StartDrink();
                break;
            case 2:
                monitor.FinishDrink();
                break;
            case 3:
                Console.WriteLine("Goodbye");
                return;
        }
    }
}


//monitor.StartDrink();
//monitor.FinishDrink();

//Console.WriteLine(monitor.State);
//Console.WriteLine(monitor.Details);

