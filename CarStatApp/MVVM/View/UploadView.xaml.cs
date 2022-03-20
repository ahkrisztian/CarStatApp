using CarStatAppLibrary.Models;
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

        private (bool isValid, CarUploadFormModel model) ValidateForm()
        {

            bool isValid = true;
            CarUploadFormModel model = new CarUploadFormModel();

            try
            {
                model.Brand = brandTextBox.Text;
                model.Type = typeTextBox.Text;
            }
            catch (Exception)
            {

                isValid = false;
            }

            return (isValid, model);

        }

        private void SaveToDatabase(CarUploadFormModel model)
        {
            MessageBox.Show($"{model.Brand}\n{model.Type}\n{model.Specification.Count}\n{model.MeasuredValuesAdac}");
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            var form = ValidateForm();

            if(form.isValid)
            {
                SaveToDatabase(form.model);
            }
            else
            {
                MessageBox.Show("The form is not valid.");
                return;
            }
        }
    }
}
