// See https://aka.ms/new-console-template for more information
using CarPricer;

PriceAdjusters a = new PriceAdjusters();

Car myCar = new Car() { 
    PurchaseValue = 35000M,
    EstimatedValue = 35000M,
    AgeInMonths = 3 * 12,
    NumberOfMiles = 50000,
    NumberOfPreviousOwners = 1,
    NumberOfCollisions = 1,
};


myCar.AddPriceAdjuster((c) => a.CollisionAdjuster(c))
    .AddPriceAdjuster((c) => a.MilesAdjuster(c))
    .AddPriceAdjuster((c) => a.AgeAdjuster(c))
    .AddPriceAdjuster((c) => a.FirstOwnerAdjuster(c))
    .AddPriceAdjuster((c) => a.OwnershipAdjuster(c));

Console.WriteLine(myCar.EstimatedValue);