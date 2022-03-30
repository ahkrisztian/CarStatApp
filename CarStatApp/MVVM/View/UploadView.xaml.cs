using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core;
using CarStatAppUI.MVVM.ViewModel;
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

namespace CarStatAppUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for UploadView.xaml
    /// </summary>
    public partial class UploadView : UserControl
    {        
        public UploadView()
        {
            InitializeComponent();           
        }

        private (bool isValid, CarModel model) ValidateForm()
        {

            bool isValid = true;
            CarModel model = new CarModel();

            try
            {
                model.Brand = brandTextBox.Text;
                model.CarType = typeTextBox.Text;
                model.HorsePower = int.Parse(horseTextBox.Text);
                model.Torque = int.Parse(torqueTextBox.Text);
                model.Transmission = transmissionTextBox.Text;
                model.MaxSpeed = Convert.ToInt32(maxSpeedTextBox.Text);
                model.NullToHundred = Convert.ToDecimal(nulltohundredTextBox.Text);
                model.TrunkProducer = Convert.ToInt32(trunkProdTextBox.Text);
                model.TankCapacity = Convert.ToInt32(tankCapTextBox.Text);
                //model.Weight = Convert.ToInt32(weightTextBox.Text);
                model.ConsumptionProducer = Convert.ToDecimal(consProdTextBox.Text);
                model.ConsumptionAdac = Convert.ToDecimal(consAdacTextBox.Text);
                model.ConsumptionCity = Convert.ToDecimal(consCityTextBox.Text);
                model.ConsumptionHighWay = Convert.ToDecimal(consHighWayTextBox.Text);
                model.ConsumptionCountryRoad = Convert.ToDecimal(consCountryTextBox.Text);
                model.RangeAdac = Convert.ToInt32(rangeTextBox.Text);
                //model.InteriorNoise = Convert.ToDecimal(noiseTextBox.Text);
                model.TrunkAdac = Convert.ToInt32(trunkAdacTextBox.Text);
        }
            catch (Exception)
            {

                isValid = false;
            }

            return (isValid, model);

        }

        private void SaveToDatabase()
        {
            string sql = "INSERT INTO Car (CarBrand, CarType, HorsePower, Torque, " +
                "Transmission, MaxSpeed, NullToHundred, TrunkProducer, TankCapacity, Weight, " +
                "ConsumptionProducer, ConsumptionAdac, ConsumptionCity, ConsumptionHighWay," +
                "ConsumptionCountryRoad, RangeAdac, InteriorNoise, TrunkAdac)" +
                " VALUES (@CarBrand, @CarType, @HorsePower, @Torque, " +
                "@Transmission, @MaxSpeed, @NullToHundred, @TrunkProducer, @TankCapacity, @Weight, " +
                "@ConsumptionProducer, @ConsumptionAdac, @ConsumptionCity, @ConsumptionHighWay," +
                "@ConsumptionCountryRoad, @RangeAdac, @InteriorNoise, @TrunkAdac)";

            Dictionary<string, object> parameters = new Dictionary<string, object> 
            {
                {"@CarBrand", brandTextBox.Text },
                {"@CarType", typeTextBox.Text },
                {"@HorsePower", horseTextBox.Text },
                {"@Transmission", transmissionTextBox.Text },
                {"@Torque", torqueTextBox.Text },
                {"@MaxSpeed", maxSpeedTextBox.Text },
                {"@NullToHundred", nulltohundredTextBox.Text },
                {"@TrunkProducer", trunkProdTextBox.Text },
                {"@TankCapacity", tankCapTextBox.Text },
                //{"@Weight", weightTextBox.Text },
                {"@ConsumptionProducer", consProdTextBox.Text },
                {"@ConsumptionAdac", consAdacTextBox.Text },
                {"@ConsumptionCity", consCityTextBox.Text },
                {"@ConsumptionHighWay", consHighWayTextBox.Text },
                {"@ConsumptionCountryRoad", consCountryTextBox.Text },
                {"@RangeAdac", rangeTextBox.Text },
                //{"@InteriorNoise", noiseTextBox.Text },
                {"@TrunkAdac", trunkAdacTextBox.Text }
            };

            SqliteDataAccess.SaveData(sql, parameters);

        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(horseTextBox.Text.ToString());
            //var form = ValidateForm();

            //if(form.isValid)
            //{
            //    SaveToDatabase();
            //}
            //else
            //{
            //    MessageBox.Show("The form is not valid.");
            //    return;
            //}
        }
    }
}
