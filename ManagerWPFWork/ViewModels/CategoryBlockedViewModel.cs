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
    public class CategoryBlockedViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Category _selectedCategoryBlocked;

        private IServiceCategory _serviceCategoryBlocked;
        public IEnumerable<Category> CategoriesBlocked { get; set; }

        public Category SelectedCategoryBlocked
        {
            get { return _selectedCategoryBlocked; }
            set
            {
                _selectedCategoryBlocked = value;
                OnPropertyChanged("SelectedCategoryBlocked");
            }
        }
        public IEnumerable<Category> CategoriesBlockedAllInfo
        {
            get => CategoriesBlocked;
            set
            {
                CategoriesBlocked = value;
                OnPropertyChanged("CategoriesBlockedAllInfo");
            }
        }
        public CategoryBlockedViewModel(IServiceCategory serviceCategoryBlocked)
        {

            _serviceCategoryBlocked = serviceCategoryBlocked;
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

            CategoriesBlocked = _serviceCategoryBlocked.GetCategoriesBlocked();

        }
    }
}
