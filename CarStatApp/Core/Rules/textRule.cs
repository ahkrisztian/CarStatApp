using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarStatAppUI.Core.Rules
{
    public class textRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal decimalNumber;
            int intNumber;

            if (decimal.TryParse((string)value, out decimalNumber))
            {
                return new ValidationResult(true, null);
            }

            if(int.TryParse((string)value, out intNumber))
            {
                return new ValidationResult(true, null);
            }

            if((string)value == "." || (string)value == ",")
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, $"Letters are not allowed here.");
        }
    }

}
