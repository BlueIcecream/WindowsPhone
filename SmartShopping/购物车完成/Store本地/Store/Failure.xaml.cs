using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Store
{
    public partial class Failure : PhoneApplicationPage
    {
        public Failure()
        {
            InitializeComponent();
        }

        private void ToFind_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void ToFind_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml", UriKind.Relative));
        }
    }
}