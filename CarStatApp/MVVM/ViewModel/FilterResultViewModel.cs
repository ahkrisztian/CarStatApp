using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core;
using CarStatAppUI.MVVM.View;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class FilterResultViewModel : ObservObj
    {
        private ObservableCollection<CarModel> _models { get; set; } = new ObservableCollection<CarModel>();

        public ObservableCollection<CarModel> Models
        {
            get
            {
                return _models;
            }
            set
            {
                if (value == _models) return;
                _models = value;
                OnPropertyChanged();
            }
        }
    }   
}
