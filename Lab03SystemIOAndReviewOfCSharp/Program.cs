﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab03SystemIOAndReviewOfCSharp
{
    public class Program
    {
        /// <summary>
        /// Insertion of the whole application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Challenge1Caller();
            Challenge2Caller();
            Challenge3Caller();
            Challenge4Caller();
            Challenge5Caller();
            Challenge6Caller();
            Challenge7Caller();
            Challenge8Caller();
            Challenge9Caller();
        }

        /// <summary>
        /// Asks the user for information and
        /// calls MultiplyInputNumber method with the provided arguments
        /// </summary>
        static void Challenge1Caller()
        {
            Console.Write("Please enter a number that is at least 3 digits long: ");
            string methodInput = Console.ReadLine();

            int output = MultiplyInputNumber(methodInput);

            Console.WriteLine($"Your product: {output}");
        }

        /// <summary>
        /// Takes in a string. It splits the string and converts each item into an int if it can.
        /// If an item is not convertable then the item gets turned into a 1.
        /// The method then multiplies them all together and returns the end product
        /// </summary>
        /// <param name="inputString">a string from Challenge1Caller</param>
        /// <returns>an integer of the product of the mulitplied input numbers</returns>
        public static int MultiplyInputNumber(string inputString)
        {
            string[] stringArray = inputString.Split(' ');

            if (stringArray.Length < 3)
                return 0;

            int product = 1;

            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(stringArray[i], out int returnValue))
                {
                    product *= returnValue;

                }
                else
                {
                    product *= 1;
                }
            }
            return product;
        }

        static void Challenge2Caller()
        {
            bool notformated = false;
            do
            {
                Console.Write("Please enter a number between 2-10: ");
                string userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out int arraySize);
                
                if (success && arraySize > 1 && arraySize < 11)
                {
                    
                    notformated = IsStillRunning(arraySize);

                }
                else
                {
                    Console.WriteLine("That's not right. Let's start again.");
                    notformated = true;
                }
            } while (notformated);

        }

        public static bool IsStillRunning(int arraySize)
        {
            bool notformated = false;
            try
            {
                int[] methodArray = new int[arraySize];
                for (int i = 0; i < methodArray.Length; i++)
                {
                    Console.Write($"{i + 1} of {methodArray.Length} - Enter a number: ");
                    int userNumber = Convert.ToInt32(Console.ReadLine());
                    if (userNumber >= 0)
                    {
                        methodArray[i] = userNumber;
                        notformated = false;
                    }
                    else
                    {
                        Console.WriteLine("That's not right. Let's start again.");
                        notformated = true;
                        break;
                    }
                }

                if (notformated == false)
                    Console.WriteLine(GetAverage(methodArray));

            }
            catch (FormatException)
            {
                Console.WriteLine("That's not right. Let's start again.");
                notformated = true;
            }

            return notformated;
        }

        public static decimal GetAverage(int[] inputArray)
        {
            int sum = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                sum += inputArray[i];
            }

            decimal sumAsDecimal = Convert.ToDecimal(sum);
            decimal lengthAsDecimal = Convert.ToDecimal(inputArray.Length);
            decimal average = sumAsDecimal/lengthAsDecimal;
            

            return average;
        }

        static void Challenge3Caller()
        {
            MakeStar();
        }

        public static void MakeStar()
        {
            int rows = 5;
            int blank = rows - 1;

            for (int i = 1; i <= rows; i++)
            {
                for(int j = 1; j <= blank; j++)
                {
                    Console.Write(" ");
                }
                blank--;
                for(int j = 1; j <= 2 * i - 1;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            blank = 1;
            for(int i = 1; i <= rows - 1; i++)
            {
                for (int k = 1; k <= blank; k++)
                {
                    Console.Write(" ");
                }
                blank++;
                for(int k = 1; k <= 2 * (rows - i) - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }      

        static void Challenge4Caller()
        {

            int[] exampleArray = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            int testDuplicateMethod = MostDuplicates(exampleArray);
            Console.WriteLine("Example: Input: [1,1,2,2,3,3,3,1,1,5,5,6,7,8,2,1,1]");
            Console.WriteLine($"output: {testDuplicateMethod}");
        }

        public static int MostDuplicates(int[] inputArray)
        {
            int[] mostArray = new int[2] {inputArray[0] , 0};

            for (int i = 0; i < inputArray.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j])
                        counter++;
                }
                if(counter > mostArray[1])
                {
                    mostArray[0] = inputArray[i];
                    mostArray[1] = counter;
                }
            }
            
            int most = mostArray[0];

            return most;
        }

        static void Challenge5Caller()
        {
            int[] exampleArray = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };
            int testFindMaximumValue = FindMaximumValue(exampleArray);
            Console.WriteLine("Example: input [5, 25, 99, 123, 78, 96, 555, 108, 4]");
            Console.WriteLine($"return: {testFindMaximumValue}");
        }

        public static int FindMaximumValue(int[] inputArray)
        {
            int comparingItem = inputArray[0];

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] > comparingItem)
                    comparingItem = inputArray[i];
            }
            return comparingItem;
        }

        static void Challenge6Caller()
        {
            string path = "../../../words.txt";

            Console.WriteLine("Please enter a word: ");
            string userString = Console.ReadLine();

            AppendWordTofile(path, userString);
        }

        static void AppendWordTofile(string path, string inputWord)
        {
            try
            {
            File.AppendAllText(path, $"{inputWord} ");

            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"That directory doesn't exist");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured: {e.Message}");
            }
        }

        static void Challenge7Caller()
        {
            string path = "../../../words.txt";

            string outputFromMethod = ReadAllTextFromFile(path);
            Console.WriteLine(outputFromMethod);
        }

        static string ReadAllTextFromFile(string path)
        {
            string result = File.ReadAllText(path);

            return result;
        }

        static void Challenge8Caller()
        {
            string path = "../../../words.txt";

            string remove = ChoseAWord(path);

            RemoveAWord(path, remove);
        }

        static string ChoseAWord(string path)
        {
            string stringFromFile = ReadAllTextFromFile(path);

            string[] words = stringFromFile.Split(" ");

            return words[1];
        }

        static void RemoveAWord(string path, string removeThisWord)
        {
            string stringFromFile = ReadAllTextFromFile(path);

            string[] words = stringFromFile.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == removeThisWord)
                    words[i] = "";
            }

            string newString = String.Join(" ", words);

            File.WriteAllText(path, newString);            
        }

        static void Challenge9Caller()
        {
            Console.WriteLine("Please enter a sentance: ");
            string userSentance = Console.ReadLine();

            string[] output = WordLengthGetter(userSentance);

            foreach (string word in output)
            {
            Console.Write($"{word} ");
            }
        }

        public static string[] WordLengthGetter(string sentance)
        {

            string[] splitString = sentance.Split(" ");

            for (int i = 0; i < splitString.Length; i++)
            {
                int wordLength = splitString[i].Length;
                splitString[i] = $"{splitString[i].ToLower()}: {wordLength}";
            }
          
            return splitString;
        }
    }
}
