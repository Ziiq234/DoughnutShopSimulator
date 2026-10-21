using DoughnutShopSimulator.Models;
using DoughnutShopSimulator.Services;

GameService simulator = new(); // Initialisation
decimal currentBalance = 10.00m;

// Main loop
for (int day = 1; day <= 10; day++)
{
    Weather currentWeather = simulator.GenerateWeather();

    Console.WriteLine($"Day: {day}");
    Console.WriteLine($"Today's Weather Forecast: {currentWeather}");
    Console.WriteLine($"Current Balance: £{currentBalance:F2}");

    int donutAmount = 0;
    decimal productionCost = 0.00m;

    while (true)
    {
        Console.Write("Cost: £0.25 per doughnut\nHow many doughnuts would you like to make?: ");

        if (!int.TryParse(Console.ReadLine(), out donutAmount) || donutAmount < 0)
        {
            Console.WriteLine("Invalid amount. Enter a whole number (0 or more).");
            continue;
        }

        productionCost = donutAmount * 0.25m;

        if (productionCost > currentBalance)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\nInvalid amount. You cannot afford that many doughnuts, That would cost £{productionCost}\nYou need: £{productionCost - currentBalance} to produce {donutAmount} donuts");
            Console.ResetColor();
            continue;
        }

        Console.WriteLine($"Are you sure you would like to produce {donutAmount} donuts\nAt the cost of {productionCost}\n\n1: Yes\n2: No");
        string choice = Console.ReadLine().Trim();
        Console.Clear();
        if (choice == "2" || choice.ToLower() == "no")
        {
            
            Console.WriteLine("Production stopped as user requested. Choose another amount...");
            continue;
        }

        if (choice == "1" || choice.ToLower() == "yes")
        {
            currentBalance -= productionCost;
            break;
        }

        Console.WriteLine("Invalid choice. Enter 1 for Yes or 2 for No.");
    }

    Console.WriteLine($"Making {donutAmount} doughnuts!");
    Console.WriteLine($"Production cost: £{productionCost:F2}");
    Console.WriteLine($"Remaining balance: £{currentBalance:F2}");

    //selling 
    decimal sellingPrice = 0.00m;

    while (true)
    {
        Console.Write("How much would you like to sell each doughnut for? £");

        if (!decimal.TryParse(Console.ReadLine(), out sellingPrice) || sellingPrice < 0)
        {
            Console.WriteLine("Invalid price. Enter a valid price of £0.00 or more.");
            continue;
        }

        break;
    }

    Console.WriteLine($"Selling price: £{sellingPrice:F2}");
    int customerAmount = simulator.CalculateCustomers(currentWeather, sellingPrice);
    Console.WriteLine($"Customers today: {customerAmount}");
    //Customer = 1 Donut Sold.
    Console.WriteLine($"Donuts Sold: {customeramount}")
}