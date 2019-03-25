using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieBooth
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadLines("cookieList.csv");
            var CookiesList = new List<Cookie>();

            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split(',');
                var cookie = new Cookie(fields[0], int.Parse(fields[1]));

                CookiesList.Add(cookie);
            }

            foreach (var cookie in CookiesList)
            {
                Console.WriteLine(cookie.Name + ", "  + cookie.InStock);
            }

            Console.WriteLine("Would you like to update inventory? Enter Y or press any key to exit.");
            string userInput = Console.ReadLine();

            while (userInput.ToUpper() == "Y")
            {
                Console.WriteLine("Would you like to add, remove, or view inventory? Enter Add, Remove, View, or press any key to exit");
                string AddRemove = Console.ReadLine();

                if (AddRemove.ToLower() == "add")
                {
                    // TODO: add cookies to inventory
                    Console.WriteLine("What cookie would you like to add?");
                    string cookieName = Console.ReadLine();
                    Console.WriteLine("How many cases would you like to add?");
                    int cookieCases = Convert.ToInt32(Console.ReadLine());

                    foreach(Cookie cookie in CookiesList)
                    {
                        if (cookie.Name.ToLower() == cookieName) {
                            cookie.InStock += cookieCases;
                            Console.WriteLine(cookie.Name + " has " + cookie.InStock + " cases in stock.");
                        }
                        else
                        {
                            Console.WriteLine("Cookie not found.");
                        }
                    }
                }

                if (AddRemove.ToLower() == "remove")
                {
                    Console.WriteLine("What cookie would you like to remove?");
                    string cookieName = Console.ReadLine();
                    Console.WriteLine("How many cases would you like to remove?");
                    int cookieCases = Convert.ToInt32(Console.ReadLine());

                    foreach (Cookie cookie in CookiesList)
                    {
                        if (cookie.Name.ToLower() == cookieName)
                        {
                            cookie.InStock -= cookieCases;
                            Console.WriteLine(cookie.Name + " has " + cookie.InStock + " cases in stock.");
                        }
                        else
                        {
                            Console.WriteLine("Cookie not found.");
                        }
                    }
                }

                if (AddRemove.ToLower() == "view")
                {
                    foreach (var cookie in CookiesList)
                    {
                        Console.WriteLine("Cookie: " + cookie.Name + " \n In Stock: " + cookie.InStock + "\n");
                    }
                }

                else
                {
                    Console.WriteLine("Would you like to update inventory? Enter Y or press any key to exit.");
                    userInput = Console.ReadLine();
                }
            }
        }
    }
}
