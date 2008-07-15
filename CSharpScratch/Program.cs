using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClrExtensions;
using ClrExtensions.Win32.Http;

namespace CSharpScratch
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new String[3, 3];


            arr[0, 0] = "Carl";
            arr[1, 0] = "Adam";
            arr[2, 0] = "Scott";
            arr[0, 1] = "Fred";
            arr[1, 1] = "Louis";
            arr[2, 1] = "Bob";
            arr[0, 2] = "Simon";
            arr[1, 2] = "Joe";
            arr[2, 2] = "Bill";

            var sorted = arr.SortByColumn(0);

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Console.Write(sorted[i, j] + ' ');
                } Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

}
