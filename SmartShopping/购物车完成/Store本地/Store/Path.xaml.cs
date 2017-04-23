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
            //HtttpPost();
        }
      
        public void Use()
        {
            if(type=="酸辣牛肉面")
            { 
                xx1 = 275.00;
                xx2 = 140.00;
                yy1 = 380.00;
                yy2 = 600.00;
                x1 = 285;
                x2 = 150;
                x3 = 150;
                x4 = 150;
                x5 = 150;
                y1 = 390;
                y2 = 390;
                y3 = 610;
                y4 = 610;
                y5 = 610;
            }
            else
            {
                xx1 = 65.00;
                xx2 = 275.00;
                yy1 = 75.00;
                yy2 = 175.00;
                x1 = 75;
                x2 = 285;
                x3 = 285;
                x4 = 285;
                x5 = 285;
                y1 = 85;
                y2 = 85;
                y3 = 185;
                y4 = 185;
                y5 = 185;
            }

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