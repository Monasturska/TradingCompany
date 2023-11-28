using BLLServiceManager.IServise;
using DTO.Model;
using ManagerWPFWork.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ManagerWPFWork.ViewModels
{
    public class SupplierViewModel : ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private Supplier _selectedSupplier;

        private IServiceSupplier _serviceSupplier;
        private string _nameSupplier;
        private string _nameSupplierChange;
        public ICommand AddSupplier { get; set; }
        public ICommand DeleteSupplier { get; set; }
        public ICommand ChangeSupplier { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IServiceSupplier serviceSupplier { get => _serviceSupplier; }
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged("SelectedSupplier");
            }
        }
        public string EnteredNameSupplier
        {
            get { return _nameSupplier; }
            set
            {
                _nameSupplier = value;
                OnPropertyChanged("EnteredNameSupplier");
            }
        }
        public string EnteredChangeNameSupplier
        {
            get { return _nameSupplierChange; }
            set
            {
                _nameSupplierChange = value;
                OnPropertyChanged("EnteredChangeNameSupplier");
            }
        }
        public IEnumerable<Supplier> SuppliersAllInfo
        {
            get => Suppliers;
            set
            {
                Suppliers = value;
                OnPropertyChanged("SuppliersAllInfo");
            }
        }
        public SupplierViewModel(IServiceSupplier serviceSupplier)
        {

            _serviceSupplier = serviceSupplier;
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
            EnteredNameSupplier = "...";
            Suppliers = _serviceSupplier.GetProducts();
            AddSupplier = new AddItemSupplierCommand(this);
            DeleteSupplier = new DeleteItemSupplierCommand(this);
            ChangeSupplier = new ChangeItemSupplierCommand(this);

        }


        public string Error { get { return null; } }

        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "EnteredNameSupplier":
                        if (string.IsNullOrEmpty(EnteredNameSupplier))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else if (!IsLetterEnter(EnteredNameSupplier))
                        {
                            MessageBox.Show("Invalid Input. Start only with letter!", "Error");

                        }

                        break;
                }

                return _result;
            }
        }



        private bool IsLetterEnter(string str)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(str))
            {
                return true;

            }
            else
            {
                return false;
            }
            // MessageBox.Show("Invalid input. Only letter allowed!", "Error");

        }
    }
}
