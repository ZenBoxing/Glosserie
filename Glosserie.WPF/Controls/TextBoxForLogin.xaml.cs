using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Glosserie.WPF.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxForLogin.xaml
    /// </summary>
    public partial class TextBoxForLogin : UserControl
    {
        public TextBoxForLogin()
        {
            InitializeComponent();
        }
    
        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBoxForLogin));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxForLogin));



        public bool isPasswordBox
        {
            get { return (bool)GetValue(isPasswordBoxProperty); }
            set { SetValue(isPasswordBoxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isPasswordBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isPasswordBoxProperty =
            DependencyProperty.Register("isPasswordBox", typeof(bool), typeof(TextBoxForLogin));

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            email.Text = passwordBox.Password;
        }
    }
}
