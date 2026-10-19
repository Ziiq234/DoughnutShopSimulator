using DoughnutShopSimulator.Models;

namespace DoughnutShopSimulator.Services;

public class GameService
{
    private readonly Random _random = new();

    public Weather GenerateWeather()
    {
        
        int weatherNumber = _random.Next(0,5);
        return (Weather)weatherNumber;
    }
}