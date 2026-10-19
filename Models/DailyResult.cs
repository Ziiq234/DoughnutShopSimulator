/* Note for self.
get = let me read it.
set = let me change it.
init = let me set it when creating the object, then lock that property from normal reassignment.
*/


namespace DoughnutShopSimulator.Models;

public class DailyResult
{
    public int Day { get; init; }

    public Weather Weather { get; init; }

    public int DoughnutsMade { get; init; }

    public int CustomerDemand { get; init; }

    public int DoughnutsSold { get; init; }

    public int UnsoldDoughnuts { get; init; }

    public decimal SellingPrice { get; init; }

    public decimal ProductionCost { get; init; }

    public decimal SalesIncome { get; init; }

    public decimal DailyProfit { get; init; }

    public decimal Balance { get; init; }
}