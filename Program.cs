using DoughnutShopSimulator.Models;
using DoughnutShopSimulator.Services;

List<GameSummary> completedGames = new();
bool keepPlaying = true;

while (keepPlaying)
{
    GameRunner game = new();
    GameSummary? summary = game.Run(completedGames.Count + 1);

    if (summary is null)
    {
        Console.WriteLine("Game stopped before completion.");
        break;
    }

    completedGames.Add(summary);

    while (true)
    {
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1: Start a new game");
        Console.WriteLine("2: Compare completed games");
        Console.WriteLine("3: Exit the program");

        string? choice = Console.ReadLine()?.Trim();

        if (choice == "1")
        {
            break;
        }

        if (choice == "2")
        {
            Console.WriteLine("\nCompleted games:");

            foreach (GameSummary gameResult in completedGames)
            {
                Console.WriteLine(
                    $"Game {gameResult.GameNumber}: " +
                    $"Profit £{gameResult.TotalProfit:F2} | " +
                    $"Sold {gameResult.DoughnutsSold} | " +
                    $"Made {gameResult.DoughnutsMade} | " +
                    $"Unsold {gameResult.UnsoldDoughnuts} | " +
                    $"Eaten by Nathan {gameResult.DoughnutsEatenByNathan} ({gameResult.NathanBuyouts} events) | " +
                    $"Sales £{gameResult.TotalSalesIncome:F2} | " +
                    $"Production cost £{gameResult.TotalProductionCost:F2} | " +
                    $"Final balance £{gameResult.FinalBalance:F2} | " +
                    $"Rating: {gameResult.BusinessRating}");
            }

            continue;
        }

    if (choice == "3")
    {
        Console.Write("Are you sure you want to leave? (yes/no): ");
        string? confirm = Console.ReadLine()?.Trim();

        if (confirm?.Equals("no", StringComparison.OrdinalIgnoreCase) == true)
        {
            Console.WriteLine("Good. Keep playing this top quailty donut simuliaor )l:");
            continue;
        }

        if (confirm?.Equals("yes", StringComparison.OrdinalIgnoreCase) != true)
        {
            Console.WriteLine($"sorry couldn't understand that (you typed {confirm.Trim()}) think you meant to type no bud. Back to the menu you go!");
            continue;
        }

        while (true)
        {
            Console.Write("Before you go, rate the game from 1 to 5: ");
            string? ratingInput = Console.ReadLine();

            if (ratingInput is null)
            {
                break;
            }

        if (int.TryParse(ratingInput, out int rating) && rating == 5)
        {
            Console.WriteLine("A perfect score! Nathan Smith definitely didn't write this prompt. Bye!");
            break;
        }

        Console.WriteLine("Hmm, that rating seems to have fallen into the doughnut fryer. Try again!");
    }

    keepPlaying = false;
    break;
}

    if (choice is null)
    {
        keepPlaying = false;
        break;
    }

        Console.WriteLine("Please enter 1, 2, or 3.");
    }
}
