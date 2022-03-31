using CarStatAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.Logic
{
    public  interface ICarStatLogic
    {
        public List<CarModel> ListofCars();

        public List<CarModel> filterCarModel(decimal noise, decimal consumption, int range, int trunk);

        public List<CarModel> LoadDefaultsMostsFromDatabase();

        public void SaveCarToDatabase(CarModel car);

        public decimal MinConsumption();

        public decimal MaxConsumption();

        public decimal MinNoise();

        public decimal MaxNoise();

        public int MinRange();

        public int MaxRange();

        public int MinTrunk();

        public int MaxTrunk();
    }
}
