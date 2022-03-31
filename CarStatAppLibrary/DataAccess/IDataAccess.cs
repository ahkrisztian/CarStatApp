using CarStatAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<CarModel> CarInventory_GetCars();
        List<CarModel> GetFilteredCarModel(decimal noise, decimal consumption, int range, int trunk);
        List<CarModel> GetMostEffCars(); 
        void CarModel_SaveToDb(CarModel car);
        decimal GetMinConsumption();
        decimal GetMaxConsumption();
        int GetMinRange();
        int GetMaxRange();
        int GetMinTrunk();
        int GetMaxTrunk();
        decimal GetMinNoise();
        decimal GetMaxNoise();

      
    }
}
