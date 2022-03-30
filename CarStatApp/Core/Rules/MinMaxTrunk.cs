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
    public  class MinMaxTrunk : ValidationRule
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                //Load a car with a minimum trunk volume
                string sqlTrunkMin = "SELECT* FROM Car WHERE TrunkAdac = (SELECT MIN(TrunkAdac) FROM Car)";

                CarModel minTrunkModel = SqliteDataAccess.LoadData<CarModel>(sqlTrunkMin, new Dictionary<string, object>()).FirstOrDefault();

                MinValue = minTrunkModel.TrunkAdac;

                //Load a car with a maximum trunk volume
                string sqlTrunkMax = "SELECT* FROM Car WHERE TrunkAdac = (SELECT MAX(TrunkAdac) FROM Car)";

                CarModel maxTrunkModel = SqliteDataAccess.LoadData<CarModel>(sqlTrunkMax, new Dictionary<string, object>()).FirstOrDefault();

                MaxValue = maxTrunkModel.TrunkAdac;

                if (Convert.ToInt32(value) < MinValue)
                {
                    return new ValidationResult(false, $"Trunk volume can't be lower than {MinValue}");
                }

                if (Convert.ToInt32(value) > MaxValue)
                {
                    return new ValidationResult(false, $"Trunk volume can't be higher than {MaxValue}");
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
