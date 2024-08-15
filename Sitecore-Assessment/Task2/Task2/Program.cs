using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter input string : ");
            string inputString = Console.ReadLine();
            Console.Write("Enter trash string string : ");
            string trashSymbolsString = Console.ReadLine();
            Console.WriteLine($"Is the word a palindrome : {IsPalindrome(inputString, trashSymbolsString)}");
            Console.ReadLine();
        }

        public static bool IsPalindrome(string inputString, string trashSymbolsString)
        {
            inputString = inputString.ToLower();
            trashSymbolsString = trashSymbolsString.ToLower();

            int left = 0;
            int right = inputString.Length - 1;

            while (left < right) 
            {
                while (left < right && trashSymbolsString.IndexOf(inputString[left]) != -1)
                {
                    left++;
                }
   
                while (left < right && trashSymbolsString.IndexOf(inputString[right]) != -1)
                {
                    right--;
                }

                if (inputString[left] != inputString[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
        
    }
}
