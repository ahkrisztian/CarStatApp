using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarStatAppUI.Core.Rules
{
    public class MinMaxConsumption : ValidationRule
    {
        public int MinCons = 1;
        public int MaxCons = 30;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (Convert.ToInt32(value) < MinCons)
                {
                    return new ValidationResult(false, $"Consumption is too low.");
                }

                if (Convert.ToInt32(value) > MaxCons)
                {
                    return new ValidationResult(false, $"Consumption is too high.");
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
