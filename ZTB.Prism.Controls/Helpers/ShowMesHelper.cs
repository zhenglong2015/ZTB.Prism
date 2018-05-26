using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZTB.Prism.Controls.Views;

namespace ZTB.Prism.Controls.Helpers
{
    /// <summary>
    /// 消息显示帮助类
    /// </summary>
    public class ShowMesHelper
    {
        /// <summary>
        /// 确认消息框
        /// </summary>
        /// <returns></returns>
        public static bool Question(string msg,string title="确认", Window owner = null)
        {
            bool res = false;
            Application.Current.Dispatcher.Invoke(() =>
            {
                ConfirmationWindow confirmationWindow = new ConfirmationWindow();
                confirmationWindow.CustomTitle = title;
                confirmationWindow.Messages = msg;
                if (!(Application.Current.MainWindow is ConfirmationWindow))
                    confirmationWindow.Owner = owner ?? Application.Current.MainWindow;
                confirmationWindow.ShowDialog();
                res = confirmationWindow.ResultState;
            });
            return res;
        }

        /// <summary>
        /// 提示消息框
        /// </summary>
        /// <returns></returns>
        public static void Info(ObservableCollection<string> msgs,string title= "提示信息" , Window owner = null)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageWindow messageWindow = new MessageWindow();
                messageWindow.CustomTitle = title;
                messageWindow.Messages = msgs;                
                messageWindow.Owner = owner ?? Application.Current.MainWindow;
                messageWindow.ShowDialog();
            });
        }

        /// <summary>
        /// 提示消息框
        /// </summary>
        /// <returns></returns>
        public static void Info(string msg, string title = "提示信息", Window owner = null)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageWindow messageWindow = new MessageWindow();
                messageWindow.CustomTitle = title;
                messageWindow.Messages.Add(msg);
                messageWindow.Owner = owner ?? Application.Current.MainWindow;
                messageWindow.ShowDialog();
            });
        }

        /// <summary>
        /// 输入消息框
        /// </summary>
        /// <returns></returns>
        public static ReturnMes InputWin(string title, string typtName, string inputText, Window owner = null)
        {
            ReturnMes returnMes = new ShowMesHelper.ReturnMes();
            string res = string.Empty;
            Application.Current.Dispatcher.Invoke(() =>
            {
                InputWindow inputWindow = new InputWindow();
                inputWindow.TitleName = title;
                inputWindow.TypeName = typtName;
                inputWindow.InputText = inputText;
                if (!(Application.Current.MainWindow is ConfirmationWindow))
                    inputWindow.Owner = owner ?? Application.Current.MainWindow;
                inputWindow.ShowDialog();
                returnMes.InputText = inputWindow.InputText;
            });
            return returnMes;
        }


        public class ReturnMes
        {
            public bool ResultState { get; set; }

            public string InputText { get; set; }
        }
    }
}
