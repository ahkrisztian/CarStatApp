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
            throw new NotImplementedException();
        }

        public List<CarModel> LoadDefaultsMostsFromDatabase()
        {
            throw new NotImplementedException();
        }

        public List<CarModel> ListofCars()
        {
            throw new NotImplementedException();
        }

        public decimal MaxConsumption()
        {
            throw new NotImplementedException();
        }

        public decimal MaxNoise()
        {
            throw new NotImplementedException();
        }

        public int MaxRange()
        {
            throw new NotImplementedException();
        }

        public int MaxTrunk()
        {
            throw new NotImplementedException();
        }

        public decimal MinConsumption()
        {
            throw new NotImplementedException();
        }

        public decimal MinNoise()
        {
            throw new NotImplementedException();
        }

        public int MinRange()
        {
            throw new NotImplementedException();
        }

        public int MinTrunk()
        {
            throw new NotImplementedException();
        }

        public void SaveCarToDatabase(CarModel car)
        {
            _dataAccess.CarModel_SaveToDb(car);
        }
    }
}
