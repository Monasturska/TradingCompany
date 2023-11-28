using DTO.Model;
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
    public class AddItemProductCommand : ICommand
    {

        private ProductViewModel _productViewModel;

        public AddItemProductCommand(ProductViewModel productViewModel)
        {

            _productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Product product = new Product();
            product.NameObj = _productViewModel.EnteredProductName;
            product.PriceIn = _productViewModel.EnteredProductPriceIn;
            product.PriceOut = _productViewModel.EnteredProductPriceOut;
            product.CategoryID = _productViewModel.EnteredProductCategory;
            product.SupplierID = _productViewModel.EnteredProductSupplier;
            product.RowInsertTime = DateTime.Now;
            product.RowUpdateTime = DateTime.Now;
            _productViewModel.serviceProduct.AddObj(product);
            MessageBox.Show("Successfully added product!", "Information");
            _productViewModel.EnteredProductName = "...";
            _productViewModel.EnteredProductPriceIn = 0;
            _productViewModel.EnteredProductPriceOut = 0;
            _productViewModel.EnteredProductCategory = 0;
            _productViewModel.EnteredProductSupplier = 0;
        }
    }
}
