using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.MVVM.ViewModel;

namespace CarStatAppUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        CarModel carQuietest = new CarModel();
        CarModel carLongest = new CarModel();
        CarModel carBiggest = new CarModel();
        CarModel carEco = new CarModel();
        public MainView()
        {
            InitializeComponent();
            LoadDefaultsMostsFromDatabase();
            
        }

        private void LoadDefaultsMostsFromDatabase()
        {

            string sqlQuietest = "SELECT * FROM Car INNER JOIN Brands ON Car.CarBrand = Brands.id WHERE InteriorNoise = (SELECT MIN(InteriorNoise) FROM Car)";
            string sqlLongest = "SELECT * FROM Car INNER JOIN Brands ON Car.CarBrand = Brands.id WHERE RangeAdac = (SELECT MAX(RangeAdac) FROM Car)";
            string sqlBiggest = "SELECT * FROM Car INNER JOIN Brands ON Car.CarBrand = Brands.id WHERE TrunkAdac = (SELECT MAX(TrunkAdac) FROM Car)";
            string sqlEco = "SELECT * FROM Car INNER JOIN Brands ON Car.CarBrand = Brands.id WHERE ConsumptionAdac = (SELECT MIN(ConsumptionAdac) FROM Car)";

            try
            {
                carQuietest = SqliteDataAccess.LoadData<CarModel>(sqlQuietest, new Dictionary<string, object>()).FirstOrDefault();
                carLongest = SqliteDataAccess.LoadData<CarModel>(sqlLongest, new Dictionary<string, object>()).FirstOrDefault();
                carBiggest = SqliteDataAccess.LoadData<CarModel>(sqlBiggest, new Dictionary<string, object>()).FirstOrDefault();
                carEco = SqliteDataAccess.LoadData<CarModel>(sqlEco, new Dictionary<string, object>()).FirstOrDefault();

                QuietestButton.Content = $"The Quietest Car:\n {carQuietest.Brand} {carQuietest.CarType}\n Interior noise level: {carQuietest.InteriorNoise} dB";
                LongestRange.Content = $"Car with the longest range:\n {carLongest.Brand} {carLongest.CarType}\n Range: {carLongest.RangeAdac} km";
                BiggestTrunk.Content = $"Car with the biggest trunk:\n {carBiggest.Brand} {carBiggest.CarType}\n Trunk volume: {carBiggest.TrunkAdac} l";
                BestEco.Content = $"Most fuel-efficient car:\n {carEco.Brand} {carEco.CarType}\n Average consumption:\n {carEco.ConsumptionAdac} l/100km";
            }
            catch
            {

                QuietestButton.Content = $"";
                LongestRange.Content = $"";
                BiggestTrunk.Content = $"";
                BestEco.Content = $"";
            }
        }

        private void QuietestButton_Click(object sender, RoutedEventArgs e)
        {
            HomeTextBlock.Text = carQuietest.PrintCar();
        }

        private void LongestRange_Click(object sender, RoutedEventArgs e)
        {
            HomeTextBlock.Text = carLongest.PrintCar();
        }

        private void BiggestTrunk_Click(object sender, RoutedEventArgs e)
        {
            HomeTextBlock.Text = carBiggest.PrintCar();
        }

        private void BestEco_Click(object sender, RoutedEventArgs e)
        {
            HomeTextBlock.Text = carEco.PrintCar();
        }
    }
}
