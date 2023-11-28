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
    class DeleteItemSupplierCommand : ICommand
    {

        private SupplierViewModel _supplierViewModel;

        public DeleteItemSupplierCommand(SupplierViewModel supplierViewModel)
        {
            _supplierViewModel = supplierViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           

            _supplierViewModel.serviceSupplier.DeleteObject(_supplierViewModel.SelectedSupplier.Id, _supplierViewModel.SelectedSupplier.IsBlocked);
            if (_supplierViewModel.SelectedSupplier.IsBlocked == true)
            {
                MessageBox.Show("Successfully unblocked supplier!", "Information");
            }
            else
            {
                MessageBox.Show("Successfully blocked supplier!", "Information");
            }
            
        }
    }
}

