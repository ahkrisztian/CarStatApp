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
        List<CarModel> recommCars = new List<CarModel>(SqliteDataAccess.GetFilteredCarModel(66, 5, 500, 200));
        public RecommendView()
        {
            InitializeComponent(); 
            ResultGrid.Visibility = Visibility.Collapsed;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {                  
            ModelsComboBox.ItemsSource = recommCars;
            ModelsComboBox.DisplayMemberPath = $"DisplayValue";
            ModelsComboBox.SelectedValuePath = "carId";

            RecommGrid.Visibility = Visibility.Collapsed;
            ResultGrid.Visibility = Visibility.Visible;

            
            
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
    }
}
