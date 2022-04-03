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

            List<CarModel> models = SqliteDataAccess.GetMostEffCars();

            try
            {
                QuietestButton.Content = $"The Quietest Car:\n {models[0].Brand} {models[0].CarType}\n Interior noise level: {models[0].InteriorNoise} dB";
                LongestRange.Content = $"Car with the longest range:\n {models[1].Brand} {models[1].CarType}\n Range: {models[1].RangeAdac} km";
                BiggestTrunk.Content = $"Car with the biggest trunk:\n {models[2].Brand} {models[2].CarType}\n Trunk volume: {models[2].TrunkAdac} l";
                BestEco.Content = $"Most fuel-efficient car:\n {models[3].Brand} {models[3].CarType}\n Average consumption:\n {models[3].ConsumptionAdac} l/100km";
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
