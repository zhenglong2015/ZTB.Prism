using Microsoft.Win32;
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

namespace ZTB.Prism.Controls.CustomControls
{

    public class BaseTextBox : TextBox
    {

     
   

        public static readonly DependencyProperty AppendIconProperty = DependencyProperty.Register("AppendIcon", typeof(string), typeof(BaseButton), new PropertyMetadata(""));
        /// 附加区域图标
        /// </summary>
        public string AppendIcon
        {
            get { return (string)GetValue(AppendIconProperty); }
            set { SetValue(AppendIconProperty, value); }
        }
    }
}
