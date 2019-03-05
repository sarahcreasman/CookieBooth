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
            var cookiesList = new List<Cookie>();

            bool firstRecord = true;
            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split(',');
                var cookie = new Cookie(fields[0], double.Parse(fields[1]), int.Parse(fields[2]));

                cookiesList.Add(cookie);
                // Console.WriteLine(cookie.Name);
            }

            foreach (var cookie in cookiesList)
            {
                Console.WriteLine(cookie.Name + ", $" + cookie.Cost + ", " + cookie.InStock);
            }


            // TODO: add while loop to continue going through until ending
            Console.WriteLine("What cookie would you like to add stock to?");
            string addCookie = Console.ReadLine();

            Console.WriteLine("How many cases are you adding?");
            string addCases = Console.ReadLine();

            Console.WriteLine("You would like to add " + addCases + " cases of " + addCookie + "? Enter Y to Confirm or hit any button to cancel.");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "Y")
            {
                Console.WriteLine("Order Added!");
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
