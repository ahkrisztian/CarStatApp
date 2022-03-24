using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarStatAppUI.Core.Rules
{
    public  class MinMaxTrunk : ValidationRule
    {
        public int MinValue = 100;
        public int MaxValue = 1500;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (Convert.ToInt32(value) < MinValue)
                {
                    return new ValidationResult(false, $"Trunk volume is too low.");
                }

                if (Convert.ToInt32(value) > MaxValue)
                {
                    return new ValidationResult(false, $"Trunk volume is too high.");
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, $"Please enter a valid trunk volume");
            }

            return new ValidationResult(true, null);
        }
    }
}
