using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }

        public decimal HorsePower { get; set; }
        public decimal Torque { get; set; }
        public string Transmission { get; set; }
        public int MaxSpeed { get; set; }
        public decimal NullToHundred { get; set; }
        public int TrankProducer { get; set; }
        public int TankCapacity { get; set; }
        public int Weight { get; set; }

        public decimal ConsumptionProducer { get; set; }
        public decimal ConsumptionAdac { get; set; }
        public decimal ConsumptionCity { get; set; }
        public decimal ConsumptionHighWay { get; set; }
        public decimal ConsumptionCountryRoad { get; set; }
        public int RangeAdac { get; set; }
        public decimal InteriorNoise { get; set; }
        public int TrankAdac{ get; set; }

    }
}
