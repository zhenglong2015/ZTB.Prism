using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZTB.Prism.UI.BaseInformation;
using ZTB.Prism.UI.BaseInformation.Views;
using ZTB.Prism.UI.Core;
using ZTB.Prism.UI.EnergyConsumption;
using ZTB.Prism.UI.Login;
using ZTB.Prism.UI.Views;

namespace ZTB.Prism.UI
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //创建一个主界面即启动页
            return Container.TryResolve<BootstrapperWin>();
        }

        protected override void InitializeShell()
        {
            //显示主页面
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //将全局命令注册到容器中
            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            //配置应用模块，注册到容器中，同时调用模块的Initialize方法
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;


            moduleCatalog.AddModule(typeof(LoginMoudle));
            moduleCatalog.AddModule(typeof(BaseInformationModule));
            moduleCatalog.AddModule(typeof(EnergyConsumptionModule));
        }



        //改变VMd的默认注册
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        var viewName = viewType.FullName;
        //        viewName = viewName.Replace("Views", "ViewModels");
        //        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        //        var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
        //        return Type.GetType(viewModelName);
        //    });
        //}
    }
}
