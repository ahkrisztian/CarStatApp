using CarStatAppLibrary.DataAccess;
using CarStatAppLibrary.Models;
using CarStatAppUI.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CarStatAppUI.MVVM.ViewModel
{
    public class UploadViewModel : ObservObj
    {
        public ListCollectionView BrandsView { get;}
        private ObservableCollection<BrandModel> Brands
        {
            get; set;
        }

        public ListCollectionView TransmissionView
        {
            get;
        }
        private ObservableCollection<TransmissionModel> Transmissions
        {
            get; set;
        }

        public UploadViewModel()
        {
            Brands = new ObservableCollection<BrandModel>(SqliteDataAccess.CarInventory_GetBrands());
            BrandsView = CollectionViewSource.GetDefaultView(Brands) as ListCollectionView;

            Transmissions = new ObservableCollection<TransmissionModel>(SqliteDataAccess.CarInventory_GetTransmissions());
            TransmissionView = CollectionViewSource.GetDefaultView(Transmissions) as ListCollectionView;
        }


        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set
            {
                if (value == _brand) return;
                _brand = value;
                OnPropertyChanged();
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _horsePower;
        public string HorsePower
        {
            get { return _horsePower; }
            set
            {
                if (value == _horsePower) return;
                _horsePower = value;
                OnPropertyChanged();
            }
        }

        private string _torque;
        public string Torque
        {
            get { return _torque; }
            set
            {
                if (value == _torque) return;
                _torque = value;
                OnPropertyChanged();
            }
        }

        private string _transmission;
        public string Transmission
        {
            get { return _transmission; }
            set
            {
                if (value == _transmission) return;
                _transmission = value;
                OnPropertyChanged();
            }
        }

        private string _maxSpeed;
        public string MaxSpeed
        {
            get { return _maxSpeed; }
            set
            {
                if (value == _maxSpeed) return;
                _maxSpeed = value;
                OnPropertyChanged();
            }
        }

        private string _nullHundred;
        public string NullHundred
        {
            get { return _nullHundred; }
            set
            {
                if (value == _nullHundred) return;
                _nullHundred = value;
                OnPropertyChanged();
            }
        }

        private string _trunkCapProd;
        public string TrunkCapProd
        {
            get { return _trunkCapProd; }
            set
            {
                if (value == _trunkCapProd) return;
                _trunkCapProd = value;
                OnPropertyChanged();
            }
        }

        private string _trunkCapAdac;
        public string TrunkCapAdac
        {
            get { return _trunkCapAdac; }
            set
            {
                if (value == _trunkCapAdac) return;
                _trunkCapAdac = value;
                OnPropertyChanged();
            }
        }

        private string _intNoise;
        public string IntNoise
        {
            get { return _intNoise; }
            set
            {
                if (value == _intNoise) return;
                _intNoise = value;
                OnPropertyChanged();
            }
        }

        private string _tankCap;
        public string TankCap
        {
            get { return _tankCap; }
            set
            {
                if (value == _tankCap) return;
                _tankCap = value;
                OnPropertyChanged();
            }
        }

        private string _consProd;
        public string ConsProd
        {
            get { return _consProd; }
            set
            {
                if (value == _consProd) return;
                _consProd = value;
                OnPropertyChanged();
            }
        }

        private string _consAdac;
        public string ConsAdac
        {
            get { return _consAdac; }
            set
            {
                if (value == _consAdac) return;
                _consAdac = value;
                OnPropertyChanged();
            }
        }

        private string _consCity;
        public string ConsCity
        {
            get { return _consCity; }
            set
            {
                if (value == _consCity) return;
                _consCity = value;
                OnPropertyChanged();
            }
        }

        private string _consCountry;
        public string ConsCountry
        {
            get { return _consCountry; }
            set
            {
                if (value == _consCountry) return;
                _consCountry = value;
                OnPropertyChanged();
            }
        }

        private string _consHighWay;
        public string ConsHighWay
        {
            get { return _consHighWay; }
            set
            {
                if (value == _consHighWay) return;
                _consHighWay = value;
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

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (value == _weight) return;
                _weight = value;
                OnPropertyChanged();
            }
        }
    }
}
