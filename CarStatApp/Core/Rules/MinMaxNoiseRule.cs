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
                MinNoise = SqliteDataAccess.GetMinNoise();

                //Load a car with a maximum interior noise level
                MaxNoise = SqliteDataAccess.GetMaxNoise();

                if (Convert.ToDecimal(value) < Math.Floor(MinNoise))
                {
                    return new ValidationResult(false, $"Noise can't be lower than {Math.Floor(MinNoise)}");
                }

                if (Convert.ToDecimal(value) > Math.Ceiling(MaxNoise))
                {
                    return new ValidationResult(false, $"Noise can't be higher than {Math.Ceiling(MaxNoise)}");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid noise level or use a . separator");
            }

            return new ValidationResult(true, null);
        }
    }
}
