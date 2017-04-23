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
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Store
{
    public partial class Path : PhoneApplicationPage
    {
        int x1, x2, x3, x4, x5, y1, y2, y3, y4, y5;
        double xx1, xx2, yy1, yy2;
      
        string type = "";
        string jason;
        public Path()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("type", out type);
           // MessageBox.Show(type);
            HtttpPost();
        }
        private void HtttpPost()
        {
            try
            {
                var request = HttpWebRequest.Create("http://139.217.14.24/SmartShopping/API/navigation.php?code=12345678&name=" + type);
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
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.SendFailure)
                {
                }
            }
        }//Post   
        public void Use()
        {
            PathTest u = new PathTest(jason);
            xx1 = Convert.ToDouble(u.x1);
            xx2 = Convert.ToDouble(u.x5);
            yy1 = Convert.ToDouble(u.y1);
            yy2 = Convert.ToDouble(u.y5);
            x1 = Convert.ToInt32(u.x1)+10;
            x2 = Convert.ToInt32(u.x2) + 10;
            x3 = Convert.ToInt32(u.x3) + 10;
            x4 = Convert.ToInt32(u.x4) + 10;
            x5 = Convert.ToInt32(u.x5) + 10;
            y1 = Convert.ToInt32(u.y1) + 10;
            y2 = Convert.ToInt32(u.y2) + 10;
            y3 = Convert.ToInt32(u.y3) + 10;
            y4 = Convert.ToInt32(u.y4) + 10;
            y5 = Convert.ToInt32(u.y5) + 10;

            Ellipse w = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 10
            };
            w.SetValue(Canvas.LeftProperty, xx1);
            w.SetValue(Canvas.TopProperty, yy1);
            Canvas.Children.Add(w);

            Ellipse e = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Green),
                StrokeThickness = 10
            };
            e.SetValue(Canvas.LeftProperty, xx2);
            e.SetValue(Canvas.TopProperty, yy2);
            Canvas.Children.Add(e);

            Line l = new Line
            { X1 = x1, X2 = x2, Y1 = y1, Y2 = y2,
                Stroke = new SolidColorBrush(Colors.Red), StrokeThickness = 6
            };
            Canvas.Children.Add(l);
            Line l1 = new Line
            {
                X1 = x2,
                X2 = x3,
                Y1 = y2,
                Y2 = y3,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 6
            };
            Canvas.Children.Add(l1);
            Line l2 = new Line
            {
                X1 = x3,
                X2 = x4,
                Y1 = y3,
                Y2 = y4,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 6
            };
            Canvas.Children.Add(l2);
            Line l3 = new Line
            {
                X1 = x4,
                X2 = x5,
                Y1 = y4,
                Y2 = y5,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 6
            };
            Canvas.Children.Add(l3);      
        }
    
        private void Find_Click(object sender, RoutedEventArgs e)
        {            
           this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void Find_Click1(object sender, RoutedEventArgs e)
        {
            Use();
        }
       
    }
}