using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Logic;
using CarStatAppLibrary.Models;
using CarStatAppxUnit.Mocks;
using Xunit;

namespace CarStatAppxUnit
{
    public class CarStatLogicTest
    {
        [Fact]

        public void AddCarToInventory_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            CarModel carModel = new CarModel
            {
                Brand = "Nissan",
                CarType = "Micra",
                ConsumptionAdac = 6.45M,
                ConsumptionCity = 6.37M,
                ConsumptionCountryRoad = 5.62M,
                ConsumptionHighWay = 7.05M,
                ConsumptionProducer = 6.26M,
                TankCapacity = 36,
                HorsePower = 71,
                NullToHundred = 12.45M,
                Id = 4,
                InteriorNoise = 72.75M,
                MaxSpeed = 152,
                RangeAdac = 544,
                Torque = 98,
                Transmission = "Manual",
                TrunkAdac = 321,
                TrunkProducer = 382,
                Weight = 980
            };

            logic.SaveCarToDatabase(carModel);

            int expected = 4;

            int actual = da.CarDb.Count;

            Assert.Equal(expected, actual);
        }
    }
}
