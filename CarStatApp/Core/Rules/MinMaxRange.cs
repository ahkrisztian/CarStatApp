using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarStatAppUI.Core.Rules
{
    public  class MinMaxRange: ValidationRule
    {
        public int MinRange = 100;
        public int MaxRange = 1300;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (Convert.ToInt32(value) < MinRange)
                {
                    return new ValidationResult(false, $"Range is too low.");
                }

                if (Convert.ToInt32(value) > MaxRange)
                {
                    return new ValidationResult(false, $"Range is too high.");
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
