using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace Store
{
    public partial class List : PhoneApplicationPage
    {
       static int i=0;
       string type;
       double h = 0;
        // MyDataContext MyDataContext;        
        public List()
        {
            
            InitializeComponent();
            this.DataContext = new MainViewModel();           
            //NavigationContext.QueryString.TryGetValue("type", out type);           
            //i= Convert.ToInt32(type);
            //MessageBox.Show(i+"");
            //for (int b = 0; b < 2; b++)
            //{
            //    MainViewModel.Set(Shop.Get(b), Shop.Get(b + 1));
            //    b++;
            //}
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("type", out type);
            if (type!="q")               
            i = Convert.ToInt32(type);            
            for (int b = 0; b < i; b++)
            {
                MainViewModel.Set(Shop.Get(b), Shop.Get(b + 1));
                h= h+Convert.ToDouble(Shop.Get(b + 1));
                b++;
            }
            QQ.Text = h + "";
        }//首先   
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            type = h.ToString();      
            this.NavigationService.Navigate(new Uri("/JieZhang.xaml?type=" + type, UriKind.Relative));
            // Frame.Navigate(typeof(ToFind));
        }
    }
}