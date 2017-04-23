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
    
    public partial class Success : PhoneApplicationPage
    {
        static int b = 0;
        public Success()
        {
            InitializeComponent();
        }

        //private void ToFind_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //}

        private void ToFind_Click1(object sender, RoutedEventArgs e)
        {
            string type;
            NavigationContext.QueryString.TryGetValue("type", out type); 
            NavigationService.Navigate(new Uri("/List.xaml?type="+type, UriKind.Relative));           
        }
    }
}