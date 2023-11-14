using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    public class PriceAdjusters
    {
        public Car AgeAdjuster(Car car)
        {
            const int MaxAgeMonths = 10 * 12;
            const decimal BasePercent = .5M / 100;
            int adjustedAge = Math.Min(MaxAgeMonths, car.AgeInMonths);
            car.EstimatedValue *= 1 - (BasePercent * adjustedAge);

            return car;
        }

        public Car CollisionAdjuster(Car car)
        {
            const int MaxCollisions = 5;
            const decimal BasePercent = 2M / 100;
            int adjustedCollisons = Math.Min(MaxCollisions, car.NumberOfCollisions);
            car.EstimatedValue *= 1 - (BasePercent * adjustedCollisons);

            return car;
        }
        public Car FirstOwnerAdjuster(Car car)
        {
            
            const decimal BasePercent = 10M / 100;
            
            if (car.NumberOfPreviousOwners == 0)
            {
                car.EstimatedValue *= BasePercent + 1;
            }
            else
            {
                car.EstimatedValue *= 1M;
            }

            return car;
        }
        public Car MilesAdjuster(Car car)
        {
            const int MaxMiles = 150000;
            const decimal BasePercent = .2M / 100;

            int adjustedMiles = Math.Min(car.NumberOfMiles, MaxMiles);
            int thousandsOfMiles = adjustedMiles / 1000;
            car.EstimatedValue *= 1 - (BasePercent * thousandsOfMiles);

            return car;
        }
        public Car OwnershipAdjuster(Car car)
        {
            const decimal BasePercent = 25M / 100;

            if(car.NumberOfPreviousOwners > 2)
            {
                car.EstimatedValue *= 1 - BasePercent;
            }

            car.EstimatedValue *= 1M;

            return car;
        }

    }
}
