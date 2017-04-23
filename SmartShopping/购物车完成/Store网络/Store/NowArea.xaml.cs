using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;

namespace Store
{
    public partial class NowArea : PhoneApplicationPage
    {
        public NowArea()
        {
            InitializeComponent();
        }    
        private void Path_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Path.xaml?type="+ myTextBox.Text, UriKind.Relative));
        }
    }
}