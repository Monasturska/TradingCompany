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
    public class CategoryViewModel : ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private Category _selectedCategory;

        private IServiceCategory _serviceCategory;
        public IEnumerable<Category> Categories { get; set; }
        private string _categoryName;
        private bool _isBlocked;
        public ICommand DeleteCategory { get; set; }
        public ICommand AddCategory { get; set; }
        public IServiceCategory ServiceCategory
        {
            get => _serviceCategory;
        }
        public string EnteredCategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                OnPropertyChanged("EnteredCategoryName");
            }
        }
        public bool EnteredIsBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                _isBlocked = value;
                OnPropertyChanged("EnteredIsBlocked");
            }
        }


        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public IEnumerable<Category> CategoriesAllInfo
        {
            get => Categories;
            set
            {
                Categories = value;
                OnPropertyChanged("CategoriesAllInfo");
            }
        }
        public CategoryViewModel(IServiceCategory serviceCategory)
        {

            _serviceCategory = serviceCategory;
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

            EnteredCategoryName = "..";
            DeleteCategory = new DeleteItemCategoryCommand(this);
            AddCategory = new AddItemCategoryCommand(this);
            Categories = _serviceCategory.GetProducts();

        }


        public bool ActionAllowed
        {
            get
            {
                return actionAllowed;
            }
            set
            {
                actionAllowed = value;
                OnPropertyChanged("ActionAllowed");

            }
        }


        private bool actionAllowed;

        public string Error { get { return null; } }

        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "EnteredCategoryName":
                        if (string.IsNullOrEmpty(EnteredCategoryName))
                        {
                            ActionAllowed = false;

                            MessageBox.Show("Input something!");
                        }
                        else if (!IsLetterEnter(EnteredCategoryName))
                        {
                            MessageBox.Show("Invalid Input. Start only with letter!");
                            ActionAllowed = false;


                        }

                        else
                        {
                            ActionAllowed = true;

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


        }


    }
}
