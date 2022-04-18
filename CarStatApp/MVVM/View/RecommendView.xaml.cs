using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CarStatApp;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core.Rules;
using CarStatAppUI.MVVM.ViewModel;

namespace CarStatAppUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for RecommendView.xaml
    /// </summary>
    public partial class RecommendView : UserControl
    {
        List<CarModel> recommCars = new List<CarModel> { };
        public RecommendView()
        {
            InitializeComponent(); 
            ResultGrid.Visibility = Visibility.Collapsed;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int range;
            int trunk;
            decimal noise;
            decimal cons;

            int.TryParse(RangeBox.Text, out range);
            int.TryParse(TrunkBox.Text, out trunk);
            decimal.TryParse(ConsBox.Text, out cons);
            decimal.TryParse(noiseTextBox.Text, out noise);
            
            if(RecommFormValidation(range, trunk, noise, cons))
            {
                recommCars = SqliteDataAccess.GetFilteredCarModel(noise, cons, range, trunk);

                if(recommCars.Count > 0)
                {
                    ModelsComboBox.ItemsSource = recommCars;
                    ModelsComboBox.DisplayMemberPath = $"DisplayValue";
                    ModelsComboBox.SelectedValuePath = "carId";

                    RecommGrid.Visibility = Visibility.Collapsed;
                    ResultGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("No results.");
                }
            }
            else
            {
                MessageBox.Show("Please, check the text boxes.");
            }            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            

            ResultGrid.Visibility = Visibility.Collapsed;
            RecommGrid.Visibility = Visibility.Visible;


        }

        private void ModelsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelsComboBox.SelectedItem != null)
            {
                CarModel car = ModelsComboBox.SelectedItem as CarModel;

                RecommTextBlock.Text = car.PrintCar();
            }

            else
            {
                RecommTextBlock.Text = "";
            }
        }

        private bool RecommFormValidation(int range, int trunk, decimal noise, decimal cons )
        {
            bool output = false;

            try
            {
                //Load a car with a minimum interior noise level
                decimal MinNoise = SqliteDataAccess.GetMinNoise();

                //Load a car with a maximum interior noise level
                decimal MaxNoise = SqliteDataAccess.GetMaxNoise();

                //Load car with the lowest consumption
                decimal MinCons = SqliteDataAccess.GetMinConsumption();

                //Load a car with a highest consumption

                decimal MaxCons = SqliteDataAccess.GetMaxConsumption();

                //Load a car with a minimum trunk volume

                int MinTrunkValue = SqliteDataAccess.GetMinTrunk();

                //Load a car with a maximum trunk volume

                int MaxTrunkValue = SqliteDataAccess.GetMaxTrunk();

                //Load a car with a minimum range

                int MinRange = SqliteDataAccess.GetMinRange();

                //Load a car with a maximum range

                int MaxRange = SqliteDataAccess.GetMaxRange();

                if ((range >= MinRange && range <= MaxRange) &&
                    (trunk >= MinTrunkValue && trunk <= MaxTrunkValue) &&
                    (noise >= Math.Floor(MinNoise) && noise <= Math.Ceiling(MaxNoise)) &&
                    (cons >= Math.Floor(MinCons) && cons <= Math.Ceiling(MaxCons))) { output = true; }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return output;
            }

            return output;
        }
    }
}
