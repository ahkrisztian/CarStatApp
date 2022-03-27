using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStatAppUI.Core;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class HomeViewModel : ObservObj
    {

        private string _carQuietest;

        public string CarQuietest
        {
            get
            {
                return _carQuietest;
            }
            set
            {
                if (value == _carQuietest) return;
                _carQuietest = value;
                OnPropertyChanged();
            }
        }

        private string _interiorNoise;

        public string InteriorNoise
        {
            get
            {
                return _interiorNoise;
            }
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
            get
            {
                return _trankAdac;
            }
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
            get
            {
                return _rangeAdac;
            }
            set
            {
                if (value == _rangeAdac) return;
                _rangeAdac = value;
                OnPropertyChanged();
            }
        }

        private string _carDetail;

        public string CarDetail
        {
            get
            {
                return _carDetail;
            }
            set
            {
                if (value == _carDetail) return;
                _carDetail = value;
                OnPropertyChanged();
            }
        }
    }
}
