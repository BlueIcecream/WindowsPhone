using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public partial class Message : PhoneApplicationPage
    {
        static int key = 1;
        static int i = 0;
        //static string jason;
        string  type;
        static string name1, price1;
        static double we;
        //MyDataContext MyDataContext;
        public Message()
        {
            InitializeComponent();         
        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("type", out type);           
            //HtttpPost();
            //MessageBox.Show(jason);
            //System.Threading.Thread.Sleep(3000); NAME.Text = "asdqw";
            //User u = new User(jason);
            //NAME.Text = u.name;
            //PRICE.Text = u.price;
            //DATA.Text = u.produced_date;
            //DATA1.Text = u.expiration_date;
        }
        //public void Use()
        //{                      
        //    //User u = new User(jason);
        //    //NAME.Text = u.name;
        //    // name1 = u.name;
        //    if (Convert.ToDouble(u.price) == 3.00)
        //    {
        //        NAME.Text = "酸辣牛肉面";
        //        name1 = "酸辣牛肉面";
        //    }
        //    else
        //    {
        //        NAME.Text = "恒大冰泉";
        //        name1 = "恒大冰泉";
        //    }   
        //    PRICE.Text = u.price;
        //    price1 = u.price;
        //    DATA.Text = u.produced_date;
        //    DATA1.Text = u.expiration_date;
            ///we = Convert.ToDouble(u.weight);
       // }        
        private void ToFind_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
             //Frame.Navigate(typeof(Path));
        }

        private  async void ToFind_Click3(object sender, RoutedEventArgs e)
        {
            Send s = new Send("1");          
            await Receive.Ret();
            //this.NavigationService.Navigate(new Uri("/Success.xaml?type=" + i, UriKind.Relative));           
            if ( /*Receive.Res()>we-100 && Receive.Res() < we+100*/key==1)
            {
                key = 2;
                Send s4 = new Send("2");
                Shop s1 = new Shop(name1, price1);
                i = i + 2;
               
                this.NavigationService.Navigate(new Uri("/Success.xaml?type=" + i, UriKind.Relative));
            }
           else if(key==2)
            {              
                Send s2 = new Send("3");
                key=1;
                this.NavigationService.Navigate(new Uri("/Failure.xaml", UriKind.Relative));               
            }                    
        }
        private void ToFind_Click4(object sender, RoutedEventArgs e)
        {          
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void ToFind_Click123(object sender, RoutedEventArgs e)
        {
            //Use();
            if(type!="6943052100110")
            {
                NAME.Text = "酸辣牛肉面";
                name1 = "酸辣牛肉面"; price1 = "3.00";
                PRICE.Text = "3.00";              
                DATA.Text = "17,03,16";
                DATA1.Text = "6个月";
                we = 80;
            }
            else
            {
                NAME.Text = "恒大冰泉";
                name1 = "恒大冰泉"; price1 = "2.00";
                PRICE.Text = "2.00";
                DATA.Text = "16,12,23";
                DATA1.Text = "18个月";
                we = 300;
            }
        }
    }
}