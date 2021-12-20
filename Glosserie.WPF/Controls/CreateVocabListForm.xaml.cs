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
    /// Interaction logic for CreateVocabListForm.xaml
    /// </summary>
    public partial class CreateVocabListForm : UserControl
    {
        public CreateVocabListForm()
        {
            InitializeComponent();
        }



        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value);}
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(CreateVocabListForm), new PropertyMetadata(false));

        public static readonly RoutedEvent OpenDropDownEvent = EventManager.RegisterRoutedEvent("OpenDropDown",RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(CreateVocabListForm));

        public event RoutedEventHandler OpenDropDown
        {
            add { AddHandler(OpenDropDownEvent, value); }
            remove { RemoveHandler(OpenDropDownEvent, value); }
        }
    }
}
