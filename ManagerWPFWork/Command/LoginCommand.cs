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
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LoginViewModel _loginViewModel;

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            if (_loginViewModel.ServiceManager.IsLogin(_loginViewModel.EmailEntered, _loginViewModel.PasswordEntered))
            {

                _loginViewModel.mainViewModel.SelectedViewModel = new ProductViewModel(_loginViewModel.mainViewModel.ServiceProduct, _loginViewModel.mainViewModel.ServiceCategory, _loginViewModel.mainViewModel.ServiceSupplier);
                _loginViewModel.mainViewModel.Loggined = true;
            }
            else
            {
                MessageBox.Show("No user exist!", "Error");
            }

        }

        public LoginCommand(LoginViewModel loginView)
        {
            _loginViewModel = loginView;
        }
    }
}
