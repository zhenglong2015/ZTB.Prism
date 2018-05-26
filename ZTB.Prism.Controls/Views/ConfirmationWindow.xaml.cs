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

namespace ZTB.Prism.Controls.Views
{
    /// <summary>
    /// ConfirmationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfirmationWindow 
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Messages
        {
            get { return (string)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(string), typeof(ConfirmationWindow), new PropertyMetadata(null));

        /// <summary>
        /// 选择结果
        /// </summary>
        public bool ResultState { get; private set; }


        public static readonly DependencyProperty CustomTitleProperty = DependencyProperty.Register("CustomTitle", typeof(string), typeof(ConfirmationWindow));
        /// <summary>
        /// 标题
        /// </summary>
        public string CustomTitle
        {
            get { return (string)GetValue(CustomTitleProperty); }
            set { SetValue(CustomTitleProperty, value); }
        }

        public ConfirmationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultState = true;
            this.Close();
            e.Handled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ResultState = false;
            this.Close();
            e.Handled = true;
        }
    }
}
