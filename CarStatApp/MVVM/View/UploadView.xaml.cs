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

            bool isValid = false;
            CarModel model = new CarModel();


            BrandModel brand = (BrandModel)brandComboBox.SelectedItem;
            TransmissionModel trans = (TransmissionModel)transmissionComboBox.SelectedItem;

            if(brand != null && trans != null)
            {
                try
                {
                    model.Brand = brand.id.ToString();
                    model.CarType = typeTextBox.Text;
                    model.HorsePower = int.Parse(horseTextBox.Text);
                    model.Torque = int.Parse(torqueTextBox.Text);
                    model.TypeTransmission = trans.id.ToString();
                    model.MaxSpeed = Convert.ToInt32(maxSpeedTextBox.Text);
                    model.NullToHundred = Convert.ToDecimal(nulltohundredTextBox.Text);
                    model.TrunkProducer = Convert.ToInt32(trunkProdTextBox.Text);
                    model.TankCapacity = Convert.ToInt32(tankCapTextBox.Text);
                    model.Weight = Convert.ToInt32(weightTextBox.Text);
                    model.ConsumptionProducer = Convert.ToDecimal(consProdTextBox.Text);
                    model.ConsumptionAdac = Convert.ToDecimal(consAdacTextBox.Text);
                    model.ConsumptionCity = Convert.ToDecimal(consCityTextBox.Text);
                    model.ConsumptionHighWay = Convert.ToDecimal(consHighWayTextBox.Text);
                    model.ConsumptionCountryRoad = Convert.ToDecimal(consCountryTextBox.Text);
                    model.RangeAdac = Convert.ToInt32(rangeTextBox.Text);
                    model.InteriorNoise = Convert.ToDecimal(noiseTextBox.Text);
                    model.TrunkAdac = Convert.ToInt32(trunkAdacTextBox.Text);

                    isValid = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return (isValid, model);

        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            var form = ValidateForm();

            if (form.isValid)
            {
                SqliteDataAccess.CarModel_SaveToDb(form.model);
                MessageBox.Show("Data has been uploaded!");
            }
            else
            {
                MessageBox.Show("The form is not valid.");
                return;
            }

        }
    }
}
