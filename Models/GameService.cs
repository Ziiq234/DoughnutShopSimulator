using DoughnutShopSimulator.Models;

namespace DoughnutShopSimulator.Services;

public class GameService
{
    private readonly Random _random = new();

    public Weather GenerateWeather()
    {
        int weatherNumber = _random.Next(0, 5);
        return (Weather)weatherNumber;
    }

    public int CalculateCustomers(Weather weather, decimal sellingPrice)
    {
        int baseCustomers;

        switch (weather)
        {
            case Weather.Sunny:
                baseCustomers = _random.Next(30, 51);
                break;

            case Weather.Cloudy:
                baseCustomers = _random.Next(20, 36);
                break;

            case Weather.Rainy:
                baseCustomers = _random.Next(10, 26);
                break;

            case Weather.Heatwave:
                baseCustomers = _random.Next(40, 61);
                break;

            case Weather.Stormy:
                baseCustomers = _random.Next(5, 16);
                break;

            default:
                baseCustomers = 0;
                break;
        }

        if (sellingPrice >= 1.50m)
        {
            baseCustomers -= (int)Math.Round(baseCustomers * 0.10);
        }
        else if (sellingPrice >= 1.25m)
        {
            baseCustomers -= (int)Math.Round(baseCustomers * 0.05);
        }
        else if (sellingPrice >= 1.00m)
        {
            baseCustomers -= (int)Math.Round(baseCustomers * 0.02);
        }
        else if (sellingPrice >= 0.75m)
        {
            // No change
        }
        else if (sellingPrice >= 0.50m)
        {
            baseCustomers += (int)Math.Round(baseCustomers * 0.03);
        }

        return baseCustomers;
    }

    public string GetBusinessRating(decimal totalProfit)
    {
        if (totalProfit >= 100m)
        {
            return "Outstanding";
        }

        if (totalProfit >= 50m)
        {
            return "Excellent";
        }

        if (totalProfit >= 0m)
        {
            return "Profitable";
        }

        return "Needs improvement";
    }
}