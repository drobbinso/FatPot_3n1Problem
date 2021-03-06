﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobbinsD_FatPot_3n_1Problem
{
    class Program
    {
        public string MyProperty { get; set; }

        static void Main(string[] args)
        {
            StartApp();
        }

        private static void StartApp()
        {
            /**
             * TODO: HANDLE DECIMALS
             */
            Console.Write("Enter a pair of comma or space-separated integers, e.g.(i, j)\nOr enter a blank line to exit: ");
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            while (!reader.EndOfStream) {
                string userInput = reader.ReadLine();
                if (userInput != "")
                {
                    string[] splitString = userInput.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (splitString.Length == 2)
                    {
                        ParseIntsAndCalculate(splitString);
                    }
                    Console.Write("Enter another pair of integers, or leave blank to exit: ");
                }
                else
                    break;
            }
            Terminate();
        }

        private static void Terminate()
        {
            Console.WriteLine("\nProgram Terminating in:");
            Thread.Sleep(500);
            Console.Write("3.....");
            Thread.Sleep(1000);
            Console.Write("2.....");
            Thread.Sleep(1000);
            Console.Write("1.....");
            Thread.Sleep(1000);
            Console.Write("Goodbye.");
        }

        private static void ParseIntsAndCalculate(string[] splitString)
        {
            try
            {
                int i = int.Parse(splitString[0]);
                int j = int.Parse(splitString[1]);
            
                if (i >= 1000000 || j >= 1000000 || i <= 0 || j <= 0)
                {
                    Console.WriteLine("Invalid integers. Both values must be less than 1,000,000 and greater than 0.");
                }
                else
                {
                    DetermineMaxCycleLength(i, j);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("You must enter whole numbers.");
            }
        }

        private static void DetermineMaxCycleLength(int i, int j)
        {
            int maxCycleLength = 0;
            if (j < i)
            {
                int placeholder = i;
                i = j;
                j = placeholder;
            }
            for (int start = i; start <= j; start++)
            {
                maxCycleLength = Compute(maxCycleLength, start);
            }
            Console.WriteLine(i + " " + j + " " + maxCycleLength);
        }

        private static int Compute(int maxCycleLength, int start)
        {
            int toCompute = start;
            int cycleLength = 1;
            while (toCompute != 1)
            {
                cycleLength++;
                if (IsOdd(toCompute))
                {
                    toCompute = 3 * toCompute + 1;
                }
                else
                    toCompute = toCompute / 2;
            }
            if (cycleLength > maxCycleLength)
                maxCycleLength = cycleLength;
            return maxCycleLength;
        }

        private static bool IsOdd(int toCompute)
        {
            return (toCompute % 2 != 0);
        }
    }
}
