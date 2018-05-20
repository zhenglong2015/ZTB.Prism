using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Prism.UI.Core;

namespace ZTB.Prism.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private string title = "ztb的第一个Prism程序";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public DelegateCommand NotificationCommand { get; set; }



        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public DelegateCommand ConfirmationCommand { get; set; }




        public InteractionRequest<INotification> CustomNotificationRequest { get; set; }
        public DelegateCommand CustomNotificationCommand { get; set; }

        public DelegateCommand<string> NavigateCommand { get; private set; }


        public MainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;

            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseCustomPopup);

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);

            CustomNotificationRequest = new InteractionRequest<INotification>();
            CustomNotificationCommand = new DelegateCommand(CustomPopup);

            //ExecuteCommand = new DelegateCommand<string>(s =>
            //{
            //    eventAggregator.GetEvent<MessageSentEvent>().Publish(s);
            //});


            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("测试", "ceshi");

            NavigateCommand = new DelegateCommand<string>(navigatePath =>
            {
                regionManager.RequestNavigate("MainRegion", navigatePath, navigationParameters);
            });
        }

        void RaiseCustomPopup()
        {
            NotificationRequest.Raise(new Notification { Content = "Notification Message", Title = "Notification" }, r => Title = "Notified");
        }

        void RaiseConfirmation()
        {
            ConfirmationRequest.Raise(new Confirmation
            {
                Title = "Confirmation",
                Content = "Confirmation Message"
            },
                r => Title = r.Confirmed ? "Confirmed" : "Not Confirmed");
        }

        void CustomPopup()
        {
            CustomNotificationRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message " }, r => Title = "Good to go");
        }
    }
}
