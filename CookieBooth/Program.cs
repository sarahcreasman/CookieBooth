/* Program Name: CookieBooth.cs
 * Written By: Sarah Creasman
 * Last Updated: March 27, 2019
 * Purpose: To update the inventory of a girl scout troops stock of cookies for Cookie Booths. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CookieBooth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reads cookieList.csv and creates CookieList
            var lines = System.IO.File.ReadLines("cookieList.csv");
            var CookiesList = new List<Cookie>();

            // Separates cookieList.csv into individual objects.
            foreach (var line in lines)
            {
                var fields = line.Split(',');
                var cookie = new Cookie(fields[0], int.Parse(fields[1])); // Creates Cookie object for each of the cookies in list

                CookiesList.Add(cookie);
            }

            // Begins the user input and while loop in order to begin program
            Console.WriteLine("Would you like to update inventory? Enter Y or press any key to exit.");
            string userInput = Console.ReadLine();

            // Creates writer to write new data
            StreamWriter writer = new StreamWriter("cookieList.csv");
            StringBuilder build = new StringBuilder();

            while (userInput.ToUpper() == "Y")
            {
                Console.WriteLine("Would you like to add, remove, or view inventory? Enter Add, Remove, View, or press any key to exit");
                string AddRemove = Console.ReadLine();

                // Adds cookies to inventory
                if (AddRemove.ToLower() == "add")
                {
                    Console.WriteLine("What cookie would you like to add?");
                    string cookieName = Console.ReadLine();
                    cookieName = cookieName.ToLower();
                    Console.WriteLine("How many cases would you like to add?");
                    int cookieCases = Convert.ToInt32(Console.ReadLine());

                    foreach(Cookie cookie in CookiesList)
                    {
                        if (cookie.Name.ToLower().Contains(cookieName)) {
                            cookie.InStock += cookieCases;
                            Console.WriteLine(cookie.Name + " has " + cookie.InStock + " cases in stock.");
                        }
                    }
                }

                // Removes cookies from inventory
                if (AddRemove.ToLower() == "remove")
                {
                    Console.WriteLine("What cookie would you like to remove?");
                    string cookieName = Console.ReadLine();
                    cookieName = cookieName.ToLower();
                    Console.WriteLine("How many cases would you like to remove?");
                    int cookieCases = Convert.ToInt32(Console.ReadLine());

                    foreach (Cookie cookie in CookiesList)
                    {
                        if (cookie.Name.ToLower().Contains(cookieName))
                        {
                            // Validates that the amount of cookies removed from stock is not greater than the amount in stock
                            if (cookieCases <= cookie.InStock)
                            {
                                cookie.InStock -= cookieCases;
                                Console.WriteLine(cookie.Name + " has " + cookie.InStock + " cases in stock.");
                            }
                            else
                            {
                                Console.WriteLine("Not enough in stock. Try again.");
                            }
                        }
                    }    
                }

                // Views cookies in inventory
                if (AddRemove.ToLower() == "view")
                {
                    foreach (var cookie in CookiesList)
                    {
                        Console.WriteLine("Cookie: " + cookie.Name + " \n In Stock: " + cookie.InStock + "\n");
                    }

                    Console.WriteLine("Would you like to update inventory? Enter Y or press any key to exit.");
                    userInput = Console.ReadLine();
                }

                // Restarts loop with any other text entry
                else
                {
                    Console.WriteLine("Would you like to update inventory? Enter Y or press any key to exit.");
                    userInput = Console.ReadLine();
                }
            }

            // Writes new total to CSV file
            foreach (Cookie cookie in CookiesList)
            {
                var NewData = cookie.Name + "," + cookie.InStock;
                build.AppendLine(NewData);
            }
            writer.Write(build.ToString());

            // Closes StreamWriter and ends the program
            writer.Close();
        }
    }
}
