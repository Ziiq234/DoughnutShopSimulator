using DoughnutShopSimulator.Models;

namespace DoughnutShopSimulator.Services;

public class GameRunner
{
    private const decimal StartingBalance = 10.00m;

    private readonly GameService _simulator = new();
    private readonly List<DailyResult> _dailyResults = new();
    private decimal _currentBalance = StartingBalance;

    public GameSummary? Run(int gameNumber)
    {
        // Main loop
        for (int day = 1; day <= 10; day++)
        {
            Weather currentWeather = _simulator.GenerateWeather();

            Console.WriteLine($"Day: {day}");
            Console.WriteLine($"Today's Weather Forecast: {currentWeather}");
            Console.WriteLine($"Current Balance: £{_currentBalance:F2}");

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

                if (productionCost > _currentBalance)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\nInvalid amount. You cannot afford that many doughnuts, That would cost £{productionCost}\nYou need: £{productionCost - _currentBalance} to produce {donutAmount} donuts");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"Are you sure you would like to produce {donutAmount} donuts\nAt the cost of {productionCost}\n\n1: Yes\n2: No");
                string? choice = Console.ReadLine();
                if (choice is null)
                {
                    Console.WriteLine("U typed nothing btw.");
                    return null;
                }

                choice = choice.Trim();
                Console.Clear();
                if (choice == "2" || choice.ToLower() == "no")
                {
                    Console.WriteLine("Production stopped as user requested. Choose another amount...");
                    continue;
                }

                if (choice == "1" || choice.ToLower() == "yes")
                {
                    _currentBalance -= productionCost;
                    break;
                }

                Console.WriteLine("Invalid choice. Enter 1 for Yes or 2 for No.");
            }

            Console.WriteLine($"Making {donutAmount} doughnuts!");
            Console.WriteLine($"Production cost: £{productionCost:F2}");
            Console.WriteLine($"Remaining balance: £{_currentBalance:F2}");

            decimal sellingPrice = 0.00m;
            int customerAmount = 0;
            int donutsSold = 0;
            int unsoldDoughnuts = 0;
            int doughnutsEatenByNathan = 0;
            decimal salesIncome = 0.00m;
            decimal eventPenalty = 0.00m;
            bool nathanBuyoutOccurred = _simulator.ShouldTriggerNathanBuyout(day);

            if (nathanBuyoutOccurred)
            {
                doughnutsEatenByNathan = donutAmount;
                eventPenalty = _currentBalance * 0.70m;
                _currentBalance -= eventPenalty;

                Console.WriteLine("\nRandom event: Bought Out By Nathan Smith!");
                Console.WriteLine($"Nathan ate all {doughnutsEatenByNathan} doughnuts and took 70% of your remaining balance (£{eventPenalty:F2}).");
                Console.WriteLine($"Balance after Nathan's visit: £{_currentBalance:F2}");
            }
            else
            {
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
                customerAmount = _simulator.CalculateCustomers(currentWeather, sellingPrice);
                Console.WriteLine($"Customers today: {customerAmount}");
                donutsSold = Math.Min(customerAmount, donutAmount);
                unsoldDoughnuts = donutAmount - donutsSold;
                if (donutsSold < customerAmount)
                {
                    Console.WriteLine($"You missed out on {customerAmount - donutsSold} customers today due to insufficient stock.");
                }

                salesIncome = donutsSold * sellingPrice;
                _currentBalance += salesIncome;
            }

            decimal dailyProfit = salesIncome - productionCost - eventPenalty;

            DailyResult result = new()
            {
                Day = day,
                Weather = currentWeather,
                DoughnutsMade = donutAmount,
                CustomerDemand = customerAmount,
                DoughnutsSold = donutsSold,
                UnsoldDoughnuts = unsoldDoughnuts,
                DoughnutsEatenByNathan = doughnutsEatenByNathan,
                NathanBuyoutOccurred = nathanBuyoutOccurred,
                SellingPrice = sellingPrice,
                ProductionCost = productionCost,
                SalesIncome = salesIncome,
                DailyProfit = dailyProfit,
                Balance = _currentBalance
            };
            _dailyResults.Add(result);

            Console.WriteLine("\nEnd-of-day report");
            Console.WriteLine($"Day: {result.Day}");
            Console.WriteLine($"Weather: {result.Weather}");
            Console.WriteLine($"Doughnuts made: {result.DoughnutsMade}");
            Console.WriteLine($"Customer demand: {result.CustomerDemand}");
            Console.WriteLine($"Doughnuts sold: {result.DoughnutsSold}");
            Console.WriteLine($"Unsold doughnuts: {result.UnsoldDoughnuts}");
            Console.WriteLine($"Doughnuts eaten by Nathan: {result.DoughnutsEatenByNathan}");
            Console.WriteLine($"Selling price: £{result.SellingPrice:F2}");
            Console.WriteLine($"Sales income: £{result.SalesIncome:F2}");
            Console.WriteLine($"Production cost: £{result.ProductionCost:F2}");
            Console.WriteLine($"Daily profit: £{result.DailyProfit:F2}");
            Console.WriteLine($"Current balance: £{result.Balance:F2}\n");
        }

        decimal totalSalesIncome = _dailyResults.Sum(result => result.SalesIncome);
        decimal totalProductionCost = _dailyResults.Sum(result => result.ProductionCost);
        decimal totalProfit = _currentBalance - StartingBalance;
        int totalDoughnutsMade = _dailyResults.Sum(result => result.DoughnutsMade);
        int totalDoughnutsSold = _dailyResults.Sum(result => result.DoughnutsSold);
        int totalUnsoldDoughnuts = _dailyResults.Sum(result => result.UnsoldDoughnuts);
        int totalDoughnutsEatenByNathan = _dailyResults.Sum(result => result.DoughnutsEatenByNathan);
        int nathanBuyouts = _dailyResults.Count(result => result.NathanBuyoutOccurred);
        string businessRating = _simulator.GetBusinessRating(totalProfit);

        Console.WriteLine("Final results after 10 days");
        Console.WriteLine($"Doughnuts made: {totalDoughnutsMade}");
        Console.WriteLine($"Doughnuts sold: {totalDoughnutsSold}");
        Console.WriteLine($"Unsold doughnuts: {totalUnsoldDoughnuts}");
        Console.WriteLine($"Doughnuts eaten by Nathan: {totalDoughnutsEatenByNathan}");
        Console.WriteLine($"Nathan Smith buyouts: {nathanBuyouts}");
        Console.WriteLine($"Total sales income: £{totalSalesIncome:F2}");
        Console.WriteLine($"Total production cost: £{totalProductionCost:F2}");
        Console.WriteLine($"Total profit: £{totalProfit:F2}");
        Console.WriteLine($"Final balance: £{_currentBalance:F2}");
        Console.WriteLine($"Business rating: {businessRating}");

        return new GameSummary
        {
            GameNumber = gameNumber,
            DoughnutsMade = totalDoughnutsMade,
            DoughnutsSold = totalDoughnutsSold,
            UnsoldDoughnuts = totalUnsoldDoughnuts,
            DoughnutsEatenByNathan = totalDoughnutsEatenByNathan,
            NathanBuyouts = nathanBuyouts,
            TotalSalesIncome = totalSalesIncome,
            TotalProductionCost = totalProductionCost,
            TotalProfit = totalProfit,
            FinalBalance = _currentBalance,
            BusinessRating = businessRating
        };
    }
}
