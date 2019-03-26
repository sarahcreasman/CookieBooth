/* Program Name: Cookie.cs
 * Written By: Sarah Creasman
 * Last Updated: March 25, 2019; 
 * Purpose: Creates a cookie object to be used by the CookieBooth.cs app */

using System;
using System.Collections.Generic;
using System.Text;

namespace CookieBooth
{
    public class Cookie
    {
        // Variables
        public string Name;
        public int InStock; // Cases of cookies in stock

        // Builds the object from information passed by Main Method
        public Cookie(string name, int inStock)
        {
            Name = name;
            InStock = inStock;
        }


    }
}
