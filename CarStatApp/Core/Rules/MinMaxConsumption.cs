using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.MVVM.View;

namespace CarStatAppUI.Core.Rules
{
    public class MinMaxConsumption : ValidationRule
    {
        public decimal minCons
        {
            get; set;
        }

        public decimal maxCons
        {
            get; set;
        }
       
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                //Load car with the lowest consumption
                string sqlconsMin = "SELECT * FROM Car WHERE ConsumptionAdac = (SELECT MIN(ConsumptionAdac) FROM Car)";

                CarModel minConModel = SqliteDataAccess.LoadData<CarModel>(sqlconsMin, new Dictionary<string, object>()).FirstOrDefault();

                minCons = minConModel.ConsumptionAdac;

                //Load a car with a highest consumption
                string sqlconsMax = "SELECT * FROM Car WHERE ConsumptionAdac = (SELECT MAX(ConsumptionAdac) FROM Car)";

                CarModel maxConModel = SqliteDataAccess.LoadData<CarModel>(sqlconsMax, new Dictionary<string, object>()).FirstOrDefault();

                maxCons = maxConModel.ConsumptionAdac;

                if (Convert.ToInt32(value) < minCons)
                {
                    return new ValidationResult(false, $"Minimum consumption must be at least {minCons}.");
                }

                if (Convert.ToInt32(value) > maxCons)
                {
                    return new ValidationResult(false, $"Maximum consumption can't be over {maxCons}");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid consumption");
            }

            return new ValidationResult(true, null);
        }
    }
}
