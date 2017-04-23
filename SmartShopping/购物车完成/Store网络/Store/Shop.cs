using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Shop
    {
        static string[] Arry = new string[5000];
        static int q = 0;
        public Shop(string a, string b)
        {
            Arry[q] = a; q++;
            Arry[q] = b; q++;
        }
        public static string Get(int i)
        {
            return Arry[i];
        }
    }
}
