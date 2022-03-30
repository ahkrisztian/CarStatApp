using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;

namespace CarStatAppUI.Core.Rules
{
    public  class MinMaxRange: ValidationRule
    {
        public int MinRange {get; set;}
        public int MaxRange {get; set;}

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                //Load a car with a minimum range
                string sqlRangeMin = "SELECT * FROM Car WHERE RangeAdac = (SELECT MIN(RangeAdac) FROM Car)";

                CarModel minRangeModel = SqliteDataAccess.LoadData<CarModel>(sqlRangeMin, new Dictionary<string, object>()).FirstOrDefault();

                MinRange = minRangeModel.RangeAdac;

                //Load a car with a maximum range
                string sqlRangeMax = "SELECT* FROM Car WHERE RangeAdac = (SELECT MAX(RangeAdac) FROM Car)";

                CarModel maxRangeModel = SqliteDataAccess.LoadData<CarModel>(sqlRangeMax, new Dictionary<string, object>()).FirstOrDefault();

                MaxRange = maxRangeModel.RangeAdac;

                if (Convert.ToInt32(value) < MinRange)
                {
                    return new ValidationResult(false, $"Range can't be lower than {MinRange}");
                }

                if (Convert.ToInt32(value) > MaxRange)
                {
                    return new ValidationResult(false, $"Range can't be higher than {MaxRange}");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid range");
            }

            return new ValidationResult(true, null);
        }
    }
}
