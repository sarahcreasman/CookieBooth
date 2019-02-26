using System;
using System.Collections.Generic;
using System.Text;

namespace CookieBooth
{
    public class Cookie
    {
        public string Name;
        public double Cost;
        public int InStock;

        public Cookie(string name, double cost, int inStock)
        {
            Name = name;
            Cost = cost;
            InStock = inStock;
        }


    }
}
