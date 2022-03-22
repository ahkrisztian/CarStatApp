using CarStatAppUI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class FilterViewModel : ObservObj, IDataErrorInfo
    {
        public string Error { get { return null; } }

        public Dictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "InteriorNoise":
                        result = CheckNoiseLevel();
                        break;
                }

                if (Errors.ContainsKey(columnName)) { Errors[columnName] = result; }
                else if (result != null) { Errors.Add(columnName, result); }

                OnPropertyChanged("Errors");
                return result;

            }
        }

        private decimal _consumptionAdac;

        public decimal ConsumptionAdac
        {
            get { return _consumptionAdac; }
            set
            {
                if (value == _consumptionAdac) return;
                _consumptionAdac = value;
                OnPropertyChanged();
            }
        }

        private decimal _interiorNoise;

        public decimal InteriorNoise
        {
            get { return _interiorNoise; }
            set
            {
                if (value == _interiorNoise) return;
                _interiorNoise = value;
                OnPropertyChanged();
            }
        }


        private int _trankAdac;
        public int TrankAdac
        {
            get { return _trankAdac; }
            set
            {
                if (value == _trankAdac) return;
                _trankAdac = value;
                OnPropertyChanged();
            }
        }

        private int _rangeAdac;
        public int RangeAdac
        {
            get { return _rangeAdac; }
            set
            {
                if (value == _rangeAdac) return;
                _rangeAdac = value;
                OnPropertyChanged();
            }
        }

        internal string CheckNoiseLevel()
        {
            if (InteriorNoise > 80)
            {
                return $"Noise level too high";
            }
            if (InteriorNoise < 60)
            {
                return $"Noise level too low";
            }

            return string.Empty;
        }
    }
}
