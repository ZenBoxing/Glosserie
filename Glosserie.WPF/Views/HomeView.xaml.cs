using Glosserie.WPF.Library.Services;
using Glosserie.WPF.ViewModels;
using Glosserie.WPF.ViewModels.Factories;
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

namespace Glosserie.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //public string Test { get; set; } = "Testing";

        public HomeView()
        {
            InitializeComponent();
            //DataContext = this;
        }
    }
}
