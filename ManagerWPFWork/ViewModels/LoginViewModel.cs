using BLLServiceManager.IServise;
using ManagerWPFWork.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ManagerWPFWork.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private IServiceManager _serviceManagerLog;
        public MainViewModel mainViewModel { get; set; }
        private string _email;
        private string _password;

        public LoginViewModel(IServiceManager serviceManagers, MainViewModel mainViewModel)
        {
            FillInfo();
            _serviceManagerLog = serviceManagers;
            LogginManager = new LoginCommand(this);
            this.mainViewModel = mainViewModel;

        }
        public ICommand LogginManager { get; set; }
        private void FillInfo()
        {

            _email = "@gmail.com";
            _password = "1";
            // this._loggined = _serviceManagerLog.IsLogin(_email, _password);
        }
        public string EmailEntered
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("EmailEntered");
            }
        }
        public string PasswordEntered
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("PasswordEntered");
            }
        }



        public IServiceManager ServiceManager
        {
            get => _serviceManagerLog;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
        public bool ActionAllowedPass
        {
            get
            {
                return actionAllowedPass;
            }
            set
            {
                actionAllowedPass = value;
                OnPropertyChanged("ActionAllowedPass");

            }
        }
        public bool ActionAllowedEmail
        {
            get
            {
                return actionAllowedEmail;
            }
            set
            {
                actionAllowedEmail = value;
                OnPropertyChanged("ActionAllowedEmail");

            }
        }


        private bool actionAllowed;
        private bool actionAllowedPass;
        private bool actionAllowedEmail;

        public string Error { get { return null; } }

        public string this[string name]
        {
            get
            {
                string _result = null;
                switch (name)
                {
                    case "EmailEntered":
                        if (string.IsNullOrEmpty(EmailEntered))
                        {
                            ActionAllowedEmail = false;

                            MessageBox.Show("Input something!");
                        }

                        else
                        {
                            ActionAllowedEmail = true;

                        }

                        break;
                    case "PasswordEntered":
                        if (string.IsNullOrEmpty(PasswordEntered))
                        {
                            ActionAllowedPass = false;

                            MessageBox.Show("Input something!");
                        }
                        else
                        {
                            ActionAllowedPass = true;

                        }

                        break;
                }
                if (ActionAllowedPass && ActionAllowedEmail)
                {
                    ActionAllowed = true;
                }
                else
                {
                    ActionAllowed = false;
                }

                return _result;
            }
        }

    }
}
