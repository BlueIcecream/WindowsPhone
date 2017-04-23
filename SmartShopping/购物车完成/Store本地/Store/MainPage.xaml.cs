using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Store.Resources;

namespace Store
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml?type=qrcode", UriKind.Relative));
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/List.xaml?type=q", UriKind.Relative));
        }
        
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BarCode.xaml", UriKind.Relative));
        }

        private void List_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BlueTooth.xaml", UriKind.Relative));
        }
    }
}