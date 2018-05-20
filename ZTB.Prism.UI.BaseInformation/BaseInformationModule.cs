using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Prism.UI.BaseInformation.Views;

namespace ZTB.Prism.UI.BaseInformation
{
    /// <summary>
    /// Prism中每个模块是包含一个从IModule继承的类，该模块会在宿主启动的时候加载，
    /// </summary>
    public class BaseInformationModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        public BaseInformationModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }


        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("LoginRegion", typeof(BaseInformationStart));
        }
    }
}
