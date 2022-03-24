using CarStatAppUI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class FilterViewModel : ObservObj
    {   

        private string _consumptionAdac;

        public string ConsumptionAdac
        {
            get { return _consumptionAdac; }
            set
            {
                if (value == _consumptionAdac) return;
                _consumptionAdac = value;
                OnPropertyChanged();
            }
        }

        private string _interiorNoise;

        public string InteriorNoise
        {
            get { return _interiorNoise; }
            set
            {
                if (value == _interiorNoise) return;
                _interiorNoise = value;
                OnPropertyChanged();
            }
        }


        private string _trankAdac;
        public string TrankAdac
        {
            get { return _trankAdac; }
            set
            {
                if (value == _trankAdac) return;
                _trankAdac = value;
                OnPropertyChanged();
            }
        }

        private string _rangeAdac;
        public string RangeAdac
        {
            get { return _rangeAdac; }
            set
            {
                if (value == _rangeAdac) return;
                _rangeAdac = value;
                OnPropertyChanged();
            }
        }
    }
}
