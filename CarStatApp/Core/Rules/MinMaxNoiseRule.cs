using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarStatAppUI.Core.Rules
{
    public class MinMaxNoiseRule : ValidationRule
    {
        public int MinNoise = 60;
        public int MaxNoise = 80;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (Convert.ToInt32(value) < MinNoise)
                {
                    return new ValidationResult(false, $"Noise level too low.");
                }

                if (Convert.ToInt32(value) > MaxNoise)
                {
                    return new ValidationResult(false, $"Noise level too high.");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a noise level");
            }

            return new ValidationResult(true, null);
        }
    }
}
