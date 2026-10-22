# Doughnut Shop Simulator: C# With Adam Project.
## 1. Document Purpose

This document describes the planned design of the Doughnut Shop Simulator before implementation begins.

The design translates the assignment requirements into a clear software structure. It records what the program must do, how the program will be divided into components, what data will be stored and which programming techniques will be demonstrated.

## 2. Project Overview

The Doughnut Shop Simulator is a C# console application that simulates operating a doughnut shop for 10 days.

The player begins with a balance of £10.00. During each day, the player decides:

- How many doughnuts to produce
- The selling price of each doughnut

Weather conditions and selling price affect customer demand. At the end of each day, the program calculates sales, production costs, profit, unsold stock and the player's updated balance.

After Day 10, the program displays the final balance, total profit and a business rating.


## 3. Project Objectives

The objectives are to:

- Produce a complete and working 10-day simulation
- Follow all mandatory requirements in the assignment brief
- Use clear and maintainable C# code
- Validate user input to prevent invalid values and application crashes
- Separate different responsibilities into appropriate methods and classes
- Store daily results in a collection
- Provide clear daily and final reports
- Test the application using normal, invalid and boundary inputs
- Keep the solution understandable so that the implementation can be explained



## 4. Scope

### 4.1 Included in the mandatory version

The mandatory version will include:

- A starting balance of £10.00
- A simulation lasting 10 days
- Random daily weather
- Player input for production quantity
- A production cost of £0.25 per doughnut
- Player input for selling price
- Customer demand based on weather and price
- Calculation of doughnuts sold
- Calculation of unsold doughnuts
- Calculation of sales income
- Calculation of production costs
- Calculation of daily profit
- Updating the player's balance
- An end-of-day report
- A final balance and total profit
- A business rating
- Input validation
- A list containing the results from each day

### 4.2 Optional features

Optional features will only be developed after the mandatory application works correctly.

Possible optional features include:

- Random events
- Different doughnut types
- Additional weather conditions
- Difficulty levels

The first planned optional feature is random events because this is suggested in the assignment brief.

### 4.3 Excluded from the first version

The following items are outside the first version:

- ImGui.NET graphical interface
- Online accounts
- Databases
- Multiplayer functionality
- Saving games between sessions
- Network features
- Payment processing

These features are unnecessary for satisfying the current assignment requirements and would add avoidable complexity.

## 5. Users and Stakeholders

### Primary user

The primary user is the player operating the simulated doughnut shop.

The player needs to have access to infomation and perform tasks such as:

- Understand the current day, weather and balance
- Enter production and pricing decisions
- Receive clear validation messages
- View the result of each business decision
- View the final outcome after 10 days



## 6. Functional Requirements

Each requirement has an identifier so that it can be linked to the implementation and test plan.

### FR-01: Start the simulation

When the simulation s tarts the user will have 10£ in there "bank"

### FR-02: Run for 10 days

The system will run the shop simulation from Day 1 through Day 10.

### FR-03: Generate weather

The system will randomly select one weather condition for each day:

- Sunny
- Cloudy
- Rainy
- Heatwave
- Stormy

### FR-04: Display daily information

The system will display the current day, weather and available balance.

### FR-05: Accept production quantity

The system will ask the player to enter the number of doughnuts to produce.

### FR-06: Validate production quantity

The system will reject production quantities that:

- Are not whole numbers
- Are negative
- Cannot be afforded using the current balance

### FR-07: Calculate production cost

The system will calculate production cost using:

Production cost = Doughnuts produced × £0.25

The production cost will be deducted from the balance.

### FR-08: Accept selling price

The system will ask the player to enter a selling price per doughnut.

### FR-09: Validate selling price

The system will reject prices that are not valid decimal numbers or are outside the accepted price rules.

The exact minimum accepted selling price will be confirmed before this requirement is implemented.

### FR-10: Calculate base customer demand

The system will calculate a random base customer count using the weather:

- Sunny: 30 to 50 customers
- Cloudy: 20 to 35 customers
- Rainy: 10 to 25 customers
- Heatwave: 40 to 60 customers
- Stormy: 5 to 15 customers

### FR-11: Apply the price adjustment

The system will adjust customer demand based on the player's selling price.

The price conditions will be checked from the highest threshold to the lowest threshold.

### FR-12: Calculate sales

The system will calculate doughnuts sold using the lower of:

- Customer demand
- Doughnuts produced

The system will not sell more doughnuts than were produced.

### FR-13: Calculate unsold stock

The system will calculate unsold doughnuts using:

Unsold doughnuts = Doughnuts produced - Doughnuts sold

Unsold doughnuts will be discarded at the end of the day.

### FR-14: Calculate sales income

The system will calculate income using:

Sales income = Doughnuts sold × Selling price

### FR-15: Calculate daily profit

The system will calculate daily profit using:

Daily profit = Sales income - Production cost

### FR-16: Update the balance

The system will add sales income to the player's balance after the production cost has been deducted.

### FR-17: Display the daily report
The system will display:
Day number
Weather
Doughnuts produced
Doughnuts sold
Unsold doughnuts
Sales income
Production cost
Daily profit
Current balance

### FR-18: Store daily results
The system will store each day's weather, production, sales, costs, profit and closing balance in a collection.

### FR-19: Display final results
After Day 10, the system will display totals for doughnuts made, sold and unsold, total sales income, production costs, profit and final balance.

### FR-20: Rate the business
The system will calculate the business rating from total profit over the 10 days:

- £100.00 or more: Outstanding
- £50.00 to £99.99: Excellent
- £0.00 to £49.99: Profitable
- Less than £0.00: Needs improvement


## 7. Non-Functional Requirements

NFR-01: Usability
Instructions, prompts, validation messages and reports shall be clear and consistent.

NFR-02: Reliability
Invalid keyboard input shall not cause the program to terminate unexpectedly.

NFR-03: Maintainability
The program shall use descriptive names and separate different responsibilities into suitable methods and files.


NFR-04: Financial accuracy
The program shall use the decimal data type for financial values.

NFR-05: Traceability
Functional requirements shall use unique identifiers so that each requirement can be linked to an implementation feature and one or more tests.