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
    public partial class Find : PhoneApplicationPage
    {
        public Find()
        {
            InitializeComponent();
        }
        private void Now_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SM.xaml", UriKind.Relative));
            //Frame.Navigate(System.);
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Now.xaml?type="+ myTextBox.Text, UriKind.Relative));
            //Frame.Navigate(System.);
        }
    }
}