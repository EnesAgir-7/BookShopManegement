using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enes_Agir
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int category { get; set; }
        public int edition { get; set; }
        public int price { get; set; }
        public string description { get; set; }

        public string sellername { get; set; }
        public int sellerno { get; set; }
        public int gender { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public int zipcode { get; set; }
        public int housenumber { get; set; }

        public override string ToString()
        {
            return title;
        }
    }
}
