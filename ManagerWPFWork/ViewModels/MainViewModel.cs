using BLLServiceManager.IServise;
using ManagerWPFWork.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagerWPFWork.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _loggined = false;
        private IServiceCategory _serviceCategory;
        private IServiceCategory _serviceCategoryBlocked;
        private IServiceProduct _serviceProduct;
        private IServiceManager _serviceManager;
        private IServiceSupplier _serviceSupplier;
        private ViewModelBase _selectedViewModel;
        private TabItem _tabControlSelectedItem;


        public MainViewModel(IServiceCategory serviceCategory, IServiceProduct serviceProduct, IServiceManager serviceManager, IServiceSupplier serviceSupplier, IServiceCategory serviceCategoryBlocked)
        {
            UpdateVM = new UpdateDGViewModelDTO(this);
            _serviceCategory = serviceCategory;
            _serviceProduct = serviceProduct;
            _serviceManager = serviceManager;
            _serviceSupplier = serviceSupplier;
            _serviceCategoryBlocked = serviceCategoryBlocked;
            _selectedViewModel = new LoginViewModel(_serviceManager, this);
        }
        public ICommand UpdateVM { get; set; }
        public ViewModelBase SelectedViewModel
        {
            get => this._selectedViewModel;
            set
            {
                this._selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public bool Loggined
        {

            get => _loggined;
            set
            {
                _loggined = value;
                OnPropertyChanged("Loggined");
            }
        }
        public IServiceCategory ServiceCategory
        {
            get => this._serviceCategory;
            set => this._serviceCategory = value;
        }
        public IServiceCategory ServiceCategoryBlocked
        {
            get => this._serviceCategoryBlocked;
            set => this._serviceCategoryBlocked = value;
        }
        public IServiceProduct ServiceProduct
        {
            get => this._serviceProduct;
            set => this._serviceProduct = value;
        }
        public IServiceSupplier ServiceSupplier
        {
            get => this._serviceSupplier;
            set => this._serviceSupplier = value;
        }
        public IServiceManager ServiceManager
        {
            get => this._serviceManager;
            set => this._serviceManager = value;
        }
        public TabItem TabControlSelectedItem
        {
            get => this._tabControlSelectedItem;
            set
            {
                this._tabControlSelectedItem = value;
                OnPropertyChanged("TabControlSelectedItem");
            }
        }

    }
}
