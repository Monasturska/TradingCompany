using BLLServiceManager.IServise;
using BLLServiceManager.Servise;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace ManagerWPFWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UnityContainer Container;
        private ViewModelBase m_ViewModel;
        public MainWindow()
        {
            ConfigureUnity();
            InitializeComponent();
            DataContext = Container.Resolve<MainViewModel>();
            m_ViewModel = new ViewModelBase();
        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IServiceCategory, ServiceCategory>()
                     .RegisterType<IServiceSupplier, ServiceSupplier>()
                     .RegisterType<IServiceProduct, ServiceProduct>()
                     .RegisterType<IServiceManager, ServiceManager>()
                     .RegisterType<ICategoryDAL, CategoryDAL>()
                     .RegisterType<ISupplierDAL, SupplierDAL>()
                     .RegisterType<IProductDAL, ProductDAL>()
                     .RegisterType<IManagerDAL, ManagerDAL>();
        }

       
    }
}
