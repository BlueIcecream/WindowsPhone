using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class MainViewModel
    {
        public static ObservableCollection<Data> ListDatas { get; set; }
        public MainViewModel()
        {
            ListDatas = new ObservableCollection<Data>();       
        }
        public static void Set(string Nam, string Pric)
        {
            ListDatas.Add(new Data { Name = Nam, Price = Pric });
        }
        public class Data
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }
    }
}
