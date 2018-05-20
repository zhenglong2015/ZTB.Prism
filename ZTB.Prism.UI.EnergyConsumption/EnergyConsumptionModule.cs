using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Prism.UI.EnergyConsumption.Views;

namespace ZTB.Prism.UI.EnergyConsumption
{
    public class EnergyConsumptionModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        public EnergyConsumptionModule(IRegionViewRegistry regionViewRegistry)
        {
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(EnergyConsumptionStart));
        }
    }
}
