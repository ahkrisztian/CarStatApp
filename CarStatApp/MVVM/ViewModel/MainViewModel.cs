using CarStatAppUI.Core;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatAppUI.MVVM.ViewModel
{
    internal class MainViewModel : ObservObj, ICloseWindow
    {

        //Close Command to Close the main window

        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }
        void CloseWindow()
        {
            Close?.Invoke();
        }

        //Relay Command, Current View
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand FilterViewCommand { get; set; }
        public RelayCommand UploadViewCommand { get; set; }

        public FilterViewModel FilterVM { get; set; }
        public HomeViewModel HomeVM { get; set; }

        public UploadViewModel UploadVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }
      

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();

            FilterVM = new FilterViewModel();

            UploadVM = new UploadViewModel();

            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            FilterViewCommand = new RelayCommand(o =>
            {
                CurrentView = FilterVM;
            });

            UploadViewCommand = new RelayCommand(o =>
            {
                CurrentView = UploadVM;
            });
        }

    }
}
