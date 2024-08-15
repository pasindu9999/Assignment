using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] field = {
            { 0,1,1,1,0 },
            { 0,1,0,1,0 },
            { 0,1,1,1,0 },
            { 1,1,1,0,0 },
            { 0,1,0,1,1 }
            };

            Minefield mineField = new Minefield(field);

            var safePath = mineField.FindSafePathForSniffer();

            if (safePath.Count > 0)
            {
                Console.WriteLine("Safe path for sniffer:");
                foreach (var safeField in safePath)
                {
                    Console.WriteLine($"({safeField.Item1}, {safeField.Item2})");
                }
            }
            else
            {
                Console.WriteLine("No safe path for sniffer");
            }


            var safePathForBoth = mineField.FindSafePathForSnifferAndAlly();
            mineField.FindSafePathForSnifferAndAlly();
            mineField.PrintSafePathsForSnifferAndAlly(safePathForBoth);

            if (safePathForBoth.Count > 0)
            {
                Console.WriteLine("Safe path for both:");
                foreach (var safeField in safePathForBoth)
                {
                    Console.WriteLine($"({safeField.Item1}, {safeField.Item2})");
                }
            }
            else
            {
                Console.WriteLine("No safe path for sniffer and Ally");
            }

            Console.ReadLine();
        }
    }
}
