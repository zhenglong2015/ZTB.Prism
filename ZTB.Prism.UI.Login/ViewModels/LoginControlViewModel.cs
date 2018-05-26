﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZTB.Prism.Controls.Helpers;

namespace ZTB.Prism.UI.Login.ViewModels
{
    public class LoginControlViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private string userName = "Admin";
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }


        private string passWord = "Admin";
        public string PassWord
        {
            get { return passWord; }
            set { SetProperty(ref passWord, value); }
        }


        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand ExitCommand { get; private set; }

        public LoginControlViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            LoginCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate("LoginRegion", "BaseInformationStart");
            }, () => { return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(PassWord); });

            ExitCommand = new DelegateCommand(() =>
            {
                ShowMesHelper.InputWin("输入面积", "面积", "1");
                if (ShowMesHelper.Question("确认退出程序?", "确认消息"))
                {
                    Application.Current.Shutdown();
                }
            });
        }
    }
}
