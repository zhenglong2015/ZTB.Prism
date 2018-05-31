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
   
    public class BaseImgButton : Button
    {
        public static readonly DependencyProperty DefaultBackgroundImgUrlProperty = DependencyProperty.Register("DefaultBackgroundImgUrl", typeof(string), typeof(BaseImgButton), new PropertyMetadata(""));
        /// 默认背景图
        /// </summary>
        public string DefaultBackgroundImgUrl
        {
            get { return (string)GetValue(DefaultBackgroundImgUrlProperty); }
            set { SetValue(DefaultBackgroundImgUrlProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundImgUrlProperty = DependencyProperty.Register("MouseOverBackgroundImgUrl", typeof(string), typeof(BaseImgButton), new PropertyMetadata(""));
        /// 鼠标悬浮背景图
        /// </summary>
        public string MouseOverBackgroundImgUrl
        {
            get { return (string)GetValue(MouseOverBackgroundImgUrlProperty); }
            set { SetValue(MouseOverBackgroundImgUrlProperty, value); }
        }
    }
}
