using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.Models
{
    public class CarModel
    {
        public int carId { get; set; }
        public string Brand { get; set; }
        public string CarType { get; set; }

        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public string TypeTransmission { get; set; }
        public int MaxSpeed { get; set; }
        public decimal NullToHundred { get; set; }
        public int TrunkProducer { get; set; }
        public int TankCapacity { get; set; }
        public int Weight { get; set; }

        public decimal ConsumptionProducer { get; set; }
        public decimal ConsumptionAdac { get; set; }
        public decimal ConsumptionCity { get; set; }
        public decimal ConsumptionHighWay { get; set; }
        public decimal ConsumptionCountryRoad { get; set; }
        public int RangeAdac { get; set; }
        public decimal InteriorNoise { get; set; }
        public int TrunkAdac { get; set; }

        public string DisplayValue
        {
            get
            {
                return $"{Brand}  {CarType}";
            }
        }
        public CarModel()
        {

        }


        public string PrintCar() =>
            $"Brand: {Brand}\n" +
            $"Type: {CarType}\n" +
            $"HorsePower: {HorsePower} HP\n" +
            $"Torque: {Torque} Nm\n" +
            $"Transmission: {TypeTransmission}\n" +
            $"Max. Speed: {MaxSpeed} km/h\n" +
            $"0-100: {NullToHundred} s\n" +
            $"Trunk Capacity (Producer): {TrunkProducer} l\n" +
            $"Trunk Capacity (ADAC): {TrunkAdac} l\n" +
            $"Weight: {Weight} kg\n" +
            $"Avg. Consumption (Producer): {ConsumptionProducer} l/100km\n" +
            $"Avg. Consumption (ADAC): {ConsumptionAdac} l/100km\n" +
            $"Avg. Consumption in City: {ConsumptionCity} l/100km\n" +
            $"Avg. Consumption on HighWay: {ConsumptionHighWay} l/100km\n" +
            $"Avg. Consumption on Country Roads: {ConsumptionCountryRoad} l/100km\n" +
            $"Max. Range (ADAC): {RangeAdac} km\n" +
            $"Interior Noise by 130 km/h: {InteriorNoise} dB\n";

    }
}
