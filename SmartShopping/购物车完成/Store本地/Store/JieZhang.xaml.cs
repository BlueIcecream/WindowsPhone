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
    public partial class JieZhang : PhoneApplicationPage
    {
        string type;
        public JieZhang()
        {          
            InitializeComponent();          
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("type", out type);
            qq.Text = type;
        }
        private void ToFind_Click2(object sender, RoutedEventArgs e)
        {
            Send s = new Send("4");
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}