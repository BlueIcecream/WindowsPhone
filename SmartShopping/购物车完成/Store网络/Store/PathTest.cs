using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Store
{
    class PathTest
    {
        private const string x1Key = "x1";
        private const string x2Key = "x2";
        private const string x3Key = "x3";
        private const string x4Key = "x4";
        private const string x5Key = "x5";
        private const string y1Key = "y1";
        private const string y2Key = "y2";
        private const string y3Key = "y3";
        private const string y4Key = "y4";
        private const string y5Key = "y5";
        public PathTest()
        {
            x1 = "";
            x2 = "";
            x3 = "";
            x4 = "";
            x5 = "";
            y1 = "";
            y2 = "";
            y3 = "";
            y4 = "";
            y5 = "";
        }
        public PathTest(string jasonString)
            : this()
        {
            JsonObject jsonObject = JsonObject.Parse(jasonString);
            x1 = jsonObject.GetNamedString(x1Key, "");
            x2 = jsonObject.GetNamedString(x2Key, "");
            x3 = jsonObject.GetNamedString(x3Key, "");
            x4 = jsonObject.GetNamedString(x4Key, "");
            x5 = jsonObject.GetNamedString(x5Key, "");

            y1 = jsonObject.GetNamedString(y1Key, "");
            y2 = jsonObject.GetNamedString(y2Key, "");
            y3 = jsonObject.GetNamedString(y3Key, "");
            y4 = jsonObject.GetNamedString(y4Key, "");
            y5 = jsonObject.GetNamedString(y5Key, "");
        }
        public string x1 { get; set; }
        public string x2 { get; set; }
        public string x3 { get; set; }
        public string x4 { get; set; }
        public string x5 { get; set; }
        public string y1 { get; set; }
        public string y2 { get; set; }
        public string y3 { get; set; }
        public string y4 { get; set; }
        public string y5 { get; set; }
    }
}
