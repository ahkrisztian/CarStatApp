using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppLibrary.Models
{
    public class CarUploadFormModel
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public List<string> Specification { get; set; } = new List<string>();
        public List<string> MeasuredValuesAdac { get; set; } = new List<string>();
    }
}
