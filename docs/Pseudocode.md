START

SET starting balance TO 10.00 SET current balance TO starting balance CREATE empty collection for daily results

FOR day FROM 1 TO 10

DISPLAY day number
DISPLAY current balance

SET weather TO GenerateWeather()
DISPLAY weather

SET doughnutsMade TO GetProductionQuantity(current balance)

SET productionCost TO doughnutsMade * 0.25
SUBTRACT productionCost FROM current balance

SET sellingPrice TO GetSellingPrice()

SET customers TO CalculateCustomers(weather, sellingPrice)

SET doughnutsSold TO smaller value of:
    customers
    doughnutsMade

SET unsoldDoughnuts TO doughnutsMade - doughnutsSold

SET salesIncome TO doughnutsSold * sellingPrice
SET dailyProfit TO salesIncome - productionCost

ADD salesIncome TO current balance

CREATE daily result containing:
    day
    weather
    doughnuts made
    doughnuts sold
    unsold doughnuts
    selling price
    customers
    sales income
    production cost
    daily profit
    current balance

ADD daily result TO daily results collection

CALL DisplayDailyReport()
END FOR

SET totalProfit TO current balance - starting balance

SET rating TO GetBusinessRating(totalProfit)

CALL DisplayFinalResult()

END