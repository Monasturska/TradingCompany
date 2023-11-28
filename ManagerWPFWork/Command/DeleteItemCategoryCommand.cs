using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ManagerWPFWork.ViewModels;

namespace ManagerWPFWork.Command
{
    public class DeleteItemCategoryCommand : ICommand
    {

        private CategoryViewModel _catViewModel;

        public DeleteItemCategoryCommand(CategoryViewModel catViewModel)
        {

            this._catViewModel = catViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _catViewModel.ServiceCategory.DeleteObject(_catViewModel.SelectedCategory.IDCat, _catViewModel.SelectedCategory.IsBlocked);
            if (_catViewModel.SelectedCategory.IsBlocked == true)
            {
                MessageBox.Show("Successfully unblocked category!", "Information");
            }
            else
            {
                MessageBox.Show("Successfully blocked category!", "Information");
            }

        }

    }
}
