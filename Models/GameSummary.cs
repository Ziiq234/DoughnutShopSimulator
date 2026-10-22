namespace DoughnutShopSimulator.Models;

public class GameSummary
{
    public int GameNumber { get; init; }
    public int DoughnutsMade { get; init; }
    public int DoughnutsSold { get; init; }
    public int UnsoldDoughnuts { get; init; }
    public int DoughnutsEatenByNathan { get; init; }
    public int NathanBuyouts { get; init; }
    public decimal TotalSalesIncome { get; init; }
    public decimal TotalProductionCost { get; init; }
    public decimal TotalProfit { get; init; }
    public decimal FinalBalance { get; init; }
    public string BusinessRating { get; init; } = "";
}