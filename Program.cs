using DoughnutShopSimulator.Models;
using DoughnutShopSimulator.Services;



GameService simulator = new();

for (int i = 0; i < 10; i++)
{
    Weather currentWeather = simulator.GenerateWeather();

    Console.WriteLine(i + ":"+currentWeather);
}

