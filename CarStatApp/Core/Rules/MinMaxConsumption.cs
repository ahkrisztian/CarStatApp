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
                minCons = SqliteDataAccess.GetMinConsumption();

                //Load a car with a highest consumption

                maxCons = SqliteDataAccess.GetMaxConsumption();

                if (Convert.ToDecimal(value) < Math.Floor(minCons))
                {
                    return new ValidationResult(false, $"Minimum consumption must be at least {Math.Floor(minCons)}.");
                }

                if (Convert.ToDecimal(value) > Math.Ceiling(maxCons))
                {
                    return new ValidationResult(false, $"Maximum consumption can't be over {Math.Ceiling(maxCons)}");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid consumption use a . separator");
            }

            return new ValidationResult(true, null);
        }
    }
}
