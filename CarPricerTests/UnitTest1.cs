using CarPricer;

namespace CarPricerTests
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateCarValue()
        {
            AssertCarValue(25313.40m, 35000m, 3 * 12, 50000, 1, 1);
            AssertCarValue(19688.20m, 35000m, 3 * 12, 150000, 1, 1);
            AssertCarValue(19688.20m, 35000m, 3 * 12, 250000, 1, 1);
            AssertCarValue(20090.00m, 35000m, 3 * 12, 250000, 1, 0);
            AssertCarValue(21657.02m, 35000m, 3 * 12, 250000, 0, 1);
        }

        private static void AssertCarValue(decimal expectValue, decimal purchaseValue,
            int ageInMonths, int numberOfMiles, int numberOfPreviousOwners, int
                numberOfCollisions)
        {

            Car car = new Car
            {
                AgeInMonths = ageInMonths,
                NumberOfCollisions = numberOfCollisions,
                NumberOfMiles = numberOfMiles,
                NumberOfPreviousOwners = numberOfPreviousOwners,
                PurchaseValue = purchaseValue,
                EstimatedValue = purchaseValue
            };
            PriceAdjusters a = new PriceAdjusters();
            car.AddPriceAdjuster((c) => a.CollisionAdjuster(c))
                    .AddPriceAdjuster((c) => a.MilesAdjuster(c))
                    .AddPriceAdjuster((c) => a.AgeAdjuster(c))
                    .AddPriceAdjuster((c) => a.FirstOwnerAdjuster(c))
                    .AddPriceAdjuster((c) => a.OwnershipAdjuster(c));

            Assert.Equal(expectValue, car.EstimatedValue);
        }
    }
}
