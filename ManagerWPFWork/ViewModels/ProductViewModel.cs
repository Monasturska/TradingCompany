using BLLServiceManager.IServise;
using DTO.Model;
using ManagerWPFWork.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ProductViewModel : ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private Tuple<Product, string, string> _selectedProduct;
        private IServiceProduct _serviceProduct;
        private IServiceSupplier _serviceSupplier;
        private IServiceCategory _serviceCategory;
        private ObservableCollection<Tuple<Product, string, string>> _productsAllInfo = new ObservableCollection<Tuple<Product, string, string>>();
        private string _productName;
        private int _productPriceIn;
        private int _productPriceOut;
        private int _category;
        private int _supplier;

        public ICommand AddProduct { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IServiceProduct serviceProduct { get => _serviceProduct; }
        public IServiceSupplier serviceSupplier { get => _serviceSupplier; }
        public IServiceCategory serviceCategory { get => _serviceCategory; }
        public Tuple<Product, string, string> SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ObservableCollection<Tuple<Product, string, string>> ProductsAllInfo
        {
            get => _productsAllInfo;
            set
            {
                _productsAllInfo = value;
                OnPropertyChanged("ProductsAllInfo");
            }
        }
        public ProductViewModel(IServiceProduct serviceProduct, IServiceCategory serviceCategory, IServiceSupplier serviceSupplier)
        {
            _serviceProduct = serviceProduct;
            _serviceCategory = serviceCategory;
            _serviceSupplier = serviceSupplier;
            FillInfo();
            AddProduct = new AddItemProductCommand(this);
        }

        public string EnteredProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged("EnteredProductName");
            }
        }
        public int EnteredProductPriceIn
        {
            get
            {
                return _productPriceIn;
            }
            set
            {
                _productPriceIn = value;
                OnPropertyChanged("EnteredProductPriceIn");
            }
        }
        public int EnteredProductPriceOut
        {
            get
            {
                return _productPriceOut;
            }
            set
            {
                _productPriceOut = value;
                OnPropertyChanged("EnteredProductPriceOut");
            }
        }
        public int EnteredProductCategory
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged("EnteredProductCategory");
            }
        }
        public int EnteredProductSupplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                _supplier = value;
                OnPropertyChanged("EnteredProductSupplier");
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void FillInfo()
        {
            EnteredProductName = "...";
            Products = _serviceProduct.GetProducts();
            Categories = _serviceCategory.GetProducts();
            Suppliers = _serviceSupplier.GetProducts();
            foreach (var product in Products)
            {
                ProductsAllInfo.Add(new Tuple<Product, string, string>
                    (product, this._serviceCategory.GetObj(product.CategoryID).TypeProduct,
                    this._serviceSupplier.GetObj(product.SupplierID).NameSupplier));

            }

        }
        private bool resultActionUndo = true;
        public string Error { get { return null; } }

        public string this[string name]
        {
            get
            {
                string _result = null;

                switch (name)
                {
                    case "EnteredProductName":
                        if (string.IsNullOrEmpty(EnteredProductName))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else if (!IsLetterEnter(EnteredProductName))
                        {
                            MessageBox.Show("Invalid Input. Start only with letter!", "Error");

                        }
                        else
                        {
                            resultActionUndo = false;
                        }
                        break;
                    case "EnteredProductPriceIn":
                        if (double.IsNaN(EnteredProductPriceIn))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else if (IsNumberEnter(EnteredProductPriceIn) == false)
                        {
                            MessageBox.Show("Invalid Input. Start only with number!", "Error");

                        }
                        else if (EnteredProductPriceIn < 0)
                        {
                            MessageBox.Show("Price must be positive", "Error");
                        }
                        else
                        {
                            resultActionUndo = false;
                        }
                        break;
                    case "EnteredProductPriceOut":
                        if (string.IsNullOrEmpty(EnteredProductPriceOut.ToString()))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else if (IsNumberEnter(EnteredProductPriceOut) == false)
                        {
                            MessageBox.Show("Invalid Input. Start only with number!", "Error");

                        }
                        else if (EnteredProductPriceOut < 0)
                        {
                            MessageBox.Show("Price must be positive", "Error");
                        }
                        else
                        {
                            resultActionUndo = false;
                        }
                        break;
                    case "EnteredProductCategory":
                        if (IsNumberEnter(EnteredProductCategory) == false)
                        {
                            MessageBox.Show("Invalid Input. Start only with number!", "Error");

                        }
                        else if (EnteredProductCategory < 0)
                        {
                            MessageBox.Show("Price must be positive", "Error");
                        }
                        else if (string.IsNullOrEmpty(EnteredProductCategory.ToString()))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else
                        {
                            resultActionUndo = false;
                        }
                        break;
                    case "EnteredProductSupplier":
                        if (IsNumberEnter(EnteredProductSupplier) == false)
                        {
                            MessageBox.Show("Invalid Input. Start only with number!", "Error");

                        }
                        else if (EnteredProductSupplier < 0)
                        {
                            MessageBox.Show("Price must be positive", "Error");

                        }
                        else if (string.IsNullOrEmpty(EnteredProductSupplier.ToString()))
                        {
                            MessageBox.Show("Input something!", "Error");
                        }
                        else
                        {
                            resultActionUndo = false;
                        }
                        break;
                }

                return _result;
            }
        }


        private bool IsNumberEnter(int str)
        {

            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(Convert.ToString(str)))
            {
                return true;

            }
            else
            {
                return false;
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
        }
    }
}
