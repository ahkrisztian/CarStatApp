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
    public class MinMaxNoiseRule : ValidationRule
    {
        public decimal MinNoise {get; set;}
        public decimal MaxNoise {get; set;}

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                //Load a car with a minimum interior noise level
                string sqlinteriorMin = "SELECT* FROM Car WHERE InteriorNoise = (SELECT MIN(InteriorNoise) FROM Car)";

                CarModel mininteriorModel = SqliteDataAccess.LoadData<CarModel>(sqlinteriorMin, new Dictionary<string, object>()).FirstOrDefault();

                MinNoise = mininteriorModel.InteriorNoise;

                //Load a car with a maximum interior noise level
                string sqlinteriorMax = "SELECT* FROM Car WHERE InteriorNoise = (SELECT MAX(InteriorNoise) FROM Car)";

                CarModel maxinteriorModel = SqliteDataAccess.LoadData<CarModel>(sqlinteriorMax, new Dictionary<string, object>()).FirstOrDefault();

                MaxNoise = maxinteriorModel.InteriorNoise;

                if (Convert.ToInt32(value) < MinNoise)
                {
                    return new ValidationResult(false, $"Noise can't be lower than {MinNoise}");
                }

                if (Convert.ToInt32(value) > MaxNoise)
                {
                    return new ValidationResult(false, $"Noise can't be higher than {MaxNoise}");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid noise level");
            }

            return new ValidationResult(true, null);
        }
    }
}
