using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppxUnit.Mocks
{
    public class MockDataAccess : IDataAccess
    {
        public List<CarModel> CarDb{ get; set; } = new List<CarModel>();

        public MockDataAccess()
        {
            CarDb.Add(new CarModel
            {
                Brand = "Audi",
                CarType = "A1",
                ConsumptionAdac = 7,
                ConsumptionCity = 8,
                ConsumptionCountryRoad = 6.25M,
                ConsumptionHighWay = 7.5M,
                ConsumptionProducer = 5.85M,
                TankCapacity = 43,
                HorsePower = 105,
                NullToHundred = 5.25M,
                carId = 1,
                InteriorNoise = 67.45M,
                MaxSpeed = 192,
                RangeAdac = 678,
                Torque = 165,
                TypeTransmission = "Manual",
                TrunkAdac = 378,
                TrunkProducer = 422,
                Weight = 1250               
            });

            CarDb.Add(new CarModel
            {
                Brand = "BMW",
                CarType = "315",
                ConsumptionAdac = 9,
                ConsumptionCity = 8,
                ConsumptionCountryRoad = 7.55M,
                ConsumptionHighWay = 6.5M,
                ConsumptionProducer = 5.65M,
                TankCapacity = 53,
                HorsePower = 155,
                NullToHundred = 7.25M,
                carId = 2,
                InteriorNoise = 68.75M,
                MaxSpeed = 210,
                RangeAdac = 755,
                Torque = 255,
                TypeTransmission = "Automatic",
                TrunkAdac = 411,
                TrunkProducer = 479,
                Weight = 1433
            });

            CarDb.Add(new CarModel
            {
                Brand = "Mazda",
                CarType = "3",
                ConsumptionAdac = 6.25M,
                ConsumptionCity = 7.56M,
                ConsumptionCountryRoad = 5.15M,
                ConsumptionHighWay = 7.85M,
                ConsumptionProducer = 6.25M,
                TankCapacity = 51,
                HorsePower = 312,
                NullToHundred = 4.05M,
                carId = 3,
                InteriorNoise = 69.25M,
                MaxSpeed = 256,
                RangeAdac = 578,
                Torque = 365,
                TypeTransmission = "Manual",
                TrunkAdac = 245,
                TrunkProducer = 291,
                Weight = 1020
            });
        }
        public List<CarModel> CarInventory_GetCars()
        {
            return CarDb;
        }

        public void CarModel_SaveToDb(CarModel car)
        {
            CarDb.Add(car);
        }

        public List<CarModel> GetFilteredCarModel(decimal noise, decimal consumption, int range, int trunk)
        {
            var cars =  CarDb.Where(x => x.InteriorNoise >= noise && x.ConsumptionAdac >= consumption && x.RangeAdac >= range && x.TrunkAdac >= trunk).ToList();

            return cars;
        }

        public decimal GetMaxConsumption()
        {
            return CarDb.Max(x => x.ConsumptionAdac);
        }

        public decimal GetMaxNoise()
        {
            return CarDb.Max(x => x.InteriorNoise);
        }

        public int GetMaxRange()
        {
            return CarDb.Max(x =>x.RangeAdac);
        }

        public int GetMaxTrunk()
        {
            return CarDb.Max(x =>x.TrunkAdac);
        }

        public decimal GetMinConsumption()
        {
            return CarDb.Min(x => x.ConsumptionAdac);
        }

        public decimal GetMinNoise()
        {
            return CarDb.Min(x=> x.InteriorNoise);
        }

        public int GetMinRange()
        {
            return CarDb.Min(x => x.RangeAdac);
        }

        public int GetMinTrunk()
        {
            return CarDb.Min(x => x.TrunkAdac);
        }

        public List<CarModel> GetMostEffCars()
        {
            List<CarModel> cars = new List<CarModel>();


            CarModel carQuietest = CarDb.Where(x => x.InteriorNoise == CarDb.Min(y => y.InteriorNoise)).FirstOrDefault();

            cars.Add(carQuietest);

            CarModel carLongest = CarDb.Where(x => x.RangeAdac == CarDb.Max(y => y.RangeAdac)).FirstOrDefault();

            cars.Add(carLongest);

            CarModel carBiggest = CarDb.Where(x => x.TrunkAdac == CarDb.Max(y => y.TrunkAdac)).FirstOrDefault();

            cars.Add(carBiggest);

            CarModel carEco = CarDb.Where(x => x.ConsumptionAdac == CarDb.Min(y => y.ConsumptionAdac)).FirstOrDefault();

            cars.Add(carEco);

            return cars;
        }
    }
}
