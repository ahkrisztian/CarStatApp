using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.Logic
{
    public class CarStatLogic : ICarStatLogic
    {
        private readonly IDataAccess _dataAccess;

        public CarStatLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<CarModel> filterCarModel(decimal noise, decimal consumption, int range, int trunk)
        {
             return _dataAccess.GetFilteredCarModel(noise, consumption, range, trunk);
        }

        public List<CarModel> LoadDefaultsMostsFromDatabase()
        {
            return _dataAccess.GetMostEffCars();
        }

        public List<CarModel> ListofCars()
        {
            return _dataAccess.CarInventory_GetCars();
        }

        public decimal MaxConsumption()
        {
            return _dataAccess.GetMaxConsumption();
        }

        public decimal MaxNoise()
        {
            return _dataAccess.GetMaxNoise();
        }

        public int MaxRange()
        {
            return _dataAccess.GetMaxRange();
        }

        public int MaxTrunk()
        {
            return _dataAccess.GetMaxTrunk();
        }

        public decimal MinConsumption()
        {
           return _dataAccess.GetMinConsumption();
        }

        public decimal MinNoise()
        {
            return _dataAccess.GetMinNoise();
        }

        public int MinRange()
        {
            return _dataAccess.GetMinRange();
        }

        public int MinTrunk()
        {
            return _dataAccess.GetMinTrunk();
        }

        public void SaveCarToDatabase(CarModel car)
        {
            _dataAccess.CarModel_SaveToDb(car);
        }
    }
}
