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

        [Fact]

        public void FilterCarModel_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            int expected = 2;

            int actual = logic.filterCarModel(67, 7, 400, 250).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoadDefaults_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            var defaults = logic.LoadDefaultsMostsFromDatabase();

            int expected = 4;

            int actual = defaults.Count;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ListOfCarModels_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            var models = logic.ListofCars();

            int expected = 3;

            int actual = models.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxConsumption_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            decimal expected = 9;

            decimal actual = logic.MaxConsumption();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinConsumptiom_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            decimal expected = 6.25M;

            decimal actual = logic.MinConsumption();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void MinNoise_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            decimal expected = 67.45M;

            decimal actual = logic.MinNoise();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxNoise_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            decimal expected = 69.25M;

            decimal actual = logic.MaxNoise();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void MinTrunk_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            int expected = 245;

            decimal actual = logic.MinTrunk();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void MaxTrunk_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            int expected = 411;

            decimal actual = logic.MaxTrunk();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void MinRange_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            int expected = 578;

            decimal actual = logic.MinRange();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void MaxRange_ShouldWork()
        {
            MockDataAccess da = new MockDataAccess();
            CarStatLogic logic = new CarStatLogic(da);

            int expected = 755;

            decimal actual = logic.MaxRange();

            Assert.Equal(expected, actual);
        }
    }
}
