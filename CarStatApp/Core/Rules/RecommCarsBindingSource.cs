using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using CarStatAppLibrary.Models;

namespace CarStatAppUI.Core.Rules
{
    public class RecommCarsBindingSource : MarkupExtension
    {
        public List<CarModel> cars
        {
            get; private set; 
        }

        public RecommCarsBindingSource(List<CarModel> Cars)
        {
            cars = Cars;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(typeof(CarModel)) as CarModel;
        }
    }
}
