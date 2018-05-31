using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZTB.Prism.Controls.CustomControls;

namespace ZTB.Prism.Controls.Helpers
{
    public static class ControlAttachProperty
    {
        #region IsOpenFileButtonBehaviorEnabledProperty 选择文件命令行为开关
        /// <summary>
        /// 选择文件命令行为开关
        /// </summary>
        public static readonly DependencyProperty IsOpenFileButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsOpenFileButtonBehaviorEnabled"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, IsOpenFileButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsOpenFileButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenFileButtonBehaviorEnabledProperty);
        }

        public static void SetIsOpenFileButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOpenFileButtonBehaviorEnabledProperty, value);
        }

        private static void IsOpenFileButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as BaseButton;
            if (e.OldValue != e.NewValue && button != null)
            {
                button.CommandBindings.Add(OpenFileCommandBinding);
            }
        }

        #endregion
        #region OpenFileCommand 选择文件命令

        /// <summary>
        /// 选择文件命令，需要使用IsClearTextButtonBehaviorEnabledChanged绑定命令
        /// </summary>
        public static RoutedUICommand OpenFileCommand { get; private set; }

        /// <summary>
        /// OpenFileCommand绑定事件
        /// </summary>
        private static readonly CommandBinding OpenFileCommandBinding;

        /// <summary>
        /// 执行OpenFileCommand
        /// </summary>
        private static void OpenFileButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            var tbox = e.Parameter as FrameworkElement;
            var txt = tbox as TextBox;
            string filter = txt.Tag == null ? "所有文件(*.*)|*.*" : txt.Tag.ToString();
            if (filter.Contains(".bin"))
            {
                filter += "|所有文件(*.*)|*.*";
            }
            if (txt == null) return;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "请选择文件";
            //“图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*”
            fd.Filter = filter;
            fd.FileName = txt.Text.Trim();
            if (fd.ShowDialog() == true)
            {
                txt.Text = fd.FileName;
            }
            tbox.Focus();
        }

        #endregion
        static ControlAttachProperty()
        {
            OpenFileCommand = new RoutedUICommand();
            OpenFileCommandBinding = new CommandBinding(OpenFileCommand);
            OpenFileCommandBinding.Executed += OpenFileButtonClick;
        }



        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached("Label", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        public static string GetLabel(DependencyObject d)
        {
            return (string)d.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }


        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBlock))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static string GetWatermark(DependencyObject d)
        {
            return (string)d.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }



        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ControlAttachProperty), new PropertyMetadata(new CornerRadius(0)));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        public static CornerRadius GetCornerRadius(DependencyObject d)
        {
            return (CornerRadius)d.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }



        #region password
        public static readonly DependencyProperty PasswordProperty =DependencyProperty.RegisterAttached("Password", typeof(string), typeof(ControlAttachProperty),  new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));
        public static readonly DependencyProperty AttachProperty =DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(ControlAttachProperty),
            new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
            typeof(ControlAttachProperty));


        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }
        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }
        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }
        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }
        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }
        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;
            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }
        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox == null)
                return;
            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }
            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
        #endregion
    }
}
