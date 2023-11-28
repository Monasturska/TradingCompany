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
    class DeleteItemProductCommand : ICommand
    {

        private ProductViewModel _productViewModel;

        public DeleteItemProductCommand(ProductViewModel productViewModel)
        {

            this._productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _productViewModel.serviceProduct.DeleteObject(_productViewModel.SelectedProduct.Item1.Id);

            MessageBox.Show("Successfully delete product!", "Information");


        }
    }
}
