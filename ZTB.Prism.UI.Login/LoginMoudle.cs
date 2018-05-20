using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Prism.UI.Login.Views;

namespace ZTB.Prism.UI.Login
{
    public class LoginMoudle : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        public LoginMoudle(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("LoginRegion", typeof(LoginControl));
        }
    }
}
