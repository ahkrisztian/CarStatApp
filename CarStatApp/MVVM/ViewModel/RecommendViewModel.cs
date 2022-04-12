using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core;
using CarStatAppUI.MVVM.View;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class RecommendViewModel : ObservObj
    {
        
        public RecommendViewModel()
        {

        }

        private bool _search;
        public bool Search
        {
            get
            {
                return _search;
            }
            set
            {
                if (value == _search) return;
                _search = value;
                OnPropertyChanged();
            }
        }

        private string _consumptionAdac;

        public string ConsumptionAdac
        {
            get
            {
                return _consumptionAdac;
            }
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

        private List<CarModel> _cars;

        public List<CarModel> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (value == _cars) return;
                _cars = value;
                OnPropertyChanged();
            }
        }
    }
}
