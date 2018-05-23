using Microsoft.Practices.Unity;
using Prism.Regions;
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
using ZTB.Prism.UI.BaseInformation.Views;
using ZTB.Prism.UI.ViewModels;

namespace ZTB.Prism.UI.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        IUnityContainer container;
        IRegionManager regionManage;
        IRegion _region;
        BaseInformationStart baseInformationStart;
        public MainWindow(IRegionManager regionManage, IUnityContainer container)
        {
            InitializeComponent();
            this.regionManage = regionManage;
            this.container = container;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            baseInformationStart = container.Resolve<BaseInformationStart>();
            _region = this.regionManage.Regions["MainRegion"];
            _region.Add(baseInformationStart);
        }
    }
}
