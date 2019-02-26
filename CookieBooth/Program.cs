using System;

namespace CookieBooth
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadLines("cookieList.csv");

            bool firstRecord = true;
            foreach (var line in lines)
            {
                if (firstRecord == true)
                {
                    firstRecord = false;
                }
                else
                {
                    var fields = line.Split(',');
                    var c = new Cookie(fields[0], double.Parse(fields[1]), int.Parse(fields[2]));
                }
            }



        }
    }
}
