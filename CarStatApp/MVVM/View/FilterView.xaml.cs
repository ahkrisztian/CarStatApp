using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core.Rules;

namespace CarStatAppUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for FilterView.xaml
    /// </summary>
    public partial class FilterView : UserControl
    {
        public FilterView()
        {
            InitializeComponent();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            //Load a car with filter options
            string sqlfilterCar = $"SELECT * FROM Car Where " +
                $"ConsumptionAdac > {consTextBox.Text} AND " +
                $"InteriorNoise > {noiseTextBox.Text} AND " +
                $"RangeAdac > {rangeTextBox.Text} AND " +
                $"TrunkAdac > {trunkTextBox.Text}";

            CarModel filterCar = SqliteDataAccess.LoadData<CarModel>(sqlfilterCar, new Dictionary<string, object>()).FirstOrDefault();
        }

    }
}
