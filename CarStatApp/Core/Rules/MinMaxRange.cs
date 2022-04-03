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

                MinRange = SqliteDataAccess.GetMinRange();

                //Load a car with a maximum range

                MaxRange = SqliteDataAccess.GetMaxRange();

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
