using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ZTB.Prism.Controls
{
    /// <summary>
    /// NotificationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow
    {
        public double SetHeight
        {
            get { return (double)GetValue(SetHeightProperty); }
            set { SetValue(SetHeightProperty, value); }
        }

        public static readonly DependencyProperty SetHeightProperty =
            DependencyProperty.Register("SetHeight", typeof(double), typeof(MessageWindow), new PropertyMetadata(120.0));

        /// <summary>
        /// 消息
        /// </summary>
        public ObservableCollection<string> Messages
        {
            get
            {
                ObservableCollection<string> msgs = (ObservableCollection<string>)GetValue(MessagesProperty);
                if (msgs != null)
                {
                    this.SetHeight = msgs.Count * 15.85 + 120;
                }
                else
                {
                    this.SetHeight = 120;
                }
                return msgs;
            }
            set
            {
                if (value != null)
                {
                    this.SetHeight = value.Count * 15.85 + 120;
                }
                else
                {
                    this.SetHeight = 120;
                }
                SetValue(MessagesProperty, value);
            }
        }
        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(ObservableCollection<string>), typeof(MessageWindow), new PropertyMetadata(new ObservableCollection<string>()));

        public static readonly DependencyProperty CustomTitleProperty = DependencyProperty.Register("CustomTitle", typeof(string), typeof(MessageWindow), new PropertyMetadata("提示"));
        /// <summary>
        /// 标题
        /// </summary>
        public string CustomTitle
        {
            get { return (string)GetValue(CustomTitleProperty); }
            set { SetValue(CustomTitleProperty, value); }
        }

     

        public MessageWindow()
        {
            InitializeComponent();
            Messages.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
