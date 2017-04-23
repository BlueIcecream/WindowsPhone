using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Store
{
    class User
    {
        private const string nameKey = "name";
        private const string priceKey = "price";
        private const string produced_dateKey = "produced_date";
        private const string expiration_dateKey = "expiration_date";
        private const string weightKey = "weight";
        public User()
        {           
            name = "";
            price = "";
            produced_date = "";
            expiration_date = "";
            weight = "";
        }
        public User(string jasonString)
            : this()
        {
            JsonObject jsonObject = JsonObject.Parse(jasonString);
            name = jsonObject.GetNamedString(nameKey, "");
            price = jsonObject.GetNamedString(priceKey, "");
            produced_date = jsonObject.GetNamedString(produced_dateKey, "");
            expiration_date = jsonObject.GetNamedString(expiration_dateKey, "");
            weight = jsonObject.GetNamedString(weightKey, "");
        }
        public string name { get; set; }
        public string price { get; set; }
        public string produced_date { get; set; }
        public string expiration_date { get; set; }
        public string weight { get; set; }
    }
}
