using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Prism.UI.Core;

namespace ZTB.Prism.UI.BaseInformation.ViewModels
{
    public class BaseInformationStartViewModel : BindableBase, INavigationAware
    {
        IEventAggregator eventAggregator;
        private string text = "基础信息录入";

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public BaseInformationStartViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<MessageSentEvent>().Subscribe(s => { System.Windows.MessageBox.Show(s); }, ThreadOption.PublisherThread, false, (filter) => filter.Contains("1"));
        }

        /// <summary>
        /// 导航中
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var pars = navigationContext.Parameters["测试"].ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
