using BLLServiceManager.IServise;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagerWPFWork.ViewModels
{
    public class ManagerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Manager _selectedManager;

        private IServiceManager _serviceManager;
        public IEnumerable<Manager> Managers { get; set; }
        // public IServiceManager serviceManager { get => _serviceManager; }
        public Manager SelectedManagers
        {
            get { return _selectedManager; }
            set
            {
                _selectedManager = value;
                OnPropertyChanged("SelectedManagers");
            }
        }
        public IEnumerable<Manager> ManagersAllInfo
        {
            get => Managers;
            set
            {
                Managers = value;
                OnPropertyChanged("ManagersAllInfo");
            }
        }
        public ManagerViewModel(IServiceManager serviceManagers)
        {

            _serviceManager = serviceManagers;
            FillInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void FillInfo()
        {

            Managers = _serviceManager.GetProducts();

        }
    }
}
