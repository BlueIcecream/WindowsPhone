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
        static int i = 0;
        static string jason;
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
            HtttpPost();
            //MessageBox.Show(jason);
            //System.Threading.Thread.Sleep(3000); NAME.Text = "asdqw";
            //User u = new User(jason);
            //NAME.Text = u.name;
            //PRICE.Text = u.price;
            //DATA.Text = u.produced_date;
            //DATA1.Text = u.expiration_date;
        }
        public void Use()
        {                      
            User u = new User(jason);
            //NAME.Text = u.name;
            // name1 = u.name;
            //if (Convert.ToDouble(u.price) == 3.00)
            //{
            //    NAME.Text = "酸辣牛肉面";
            //    name1 = "酸辣牛肉面";
            //}
            //else
            //{
            //    NAME.Text = "恒大冰泉";
            //    name1 = "恒大冰泉";
            //}   
            NAME.Text = u.name;
            name1 =
           PRICE.Text = u.price;
            price1 = u.price;
            DATA.Text = u.produced_date;
            DATA1.Text = u.expiration_date;
            we = Convert.ToDouble(u.weight);
        }
        //139.217.14.24
        private void HtttpPost()
        {            
                try
            {                  
                var request = HttpWebRequest.Create("http://123.206.23.219/SmartShopping/API/SelectCommodity.php?code="+ type);
                    request.Method = "POST";

                    request.BeginGetRequestStream(ResponseStreamCallbackPost, request);
                    //Use();
                    return;
                    //request.BeginGetResponse(ResponseCallbackPost, request);
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.SendFailure)
                    {
                    }
                }            
        }
        private void ResponseStreamCallbackPost(IAsyncResult result)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                Stream stream = httpWebRequest.EndGetRequestStream(result);
                string postString = "q";
                byte[] data = Encoding.UTF8.GetBytes(postString);
                stream.Write(data, 0, data.Length);
                stream.Dispose();
                httpWebRequest.BeginGetResponse(ResponseCallbackPost, httpWebRequest);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {
                }
            }
        }
        private void ResponseCallbackPost(IAsyncResult result)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                WebResponse webResponse = httpWebRequest.EndGetResponse(result);
                using (Stream stream = webResponse.GetResponseStream())
                 using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    jason = content;
                    //await this.Dispatcher.BeginInvoke(Action);               
                    //await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    //{
                    //    info.Text = content;
                    //});
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {
                }
            }
        }//Post



        private void ToFind_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
             //Frame.Navigate(typeof(Path));
        }

        private async  void ToFind_Click3(object sender, RoutedEventArgs e)
        {
            Send s = new Send("1");          
            await Receive.Ret(); 
            
           
            //MessageBox.Show(Receive.Res()+"");
            //this.NavigationService.Navigate(new Uri("/Success.xaml?type="+i, UriKind.Relative));
            if ( Receive.Res()>we-100 && Receive.Res() < we+100)
            {    
                Send s2 = new Send("2");
                Shop s1 = new Shop(name1, price1);
                i = i + 2; 
                this.NavigationService.Navigate(new Uri("/Success.xaml?type=" + i, UriKind.Relative));
            }
            else
            {              
                Send s2 = new Send("3");
                this.NavigationService.Navigate(new Uri("/Failure.xaml", UriKind.Relative));               
            }                    
        }
        private void ToFind_Click4(object sender, RoutedEventArgs e)
        {          
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void ToFind_Click123(object sender, RoutedEventArgs e)
        {
            Use();
        }
    }
}