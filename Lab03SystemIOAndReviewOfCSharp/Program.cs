using System;
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

        /// <summary>
        /// Asks the user for a number. It checks to make sure the number is valid and makes a new array with 
        /// its length based off that number. Then asks for a series of numbers to fill that array. Each time
        /// it checks to make sure the number is a positive number
        /// </summary>
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

        /// <summary>
        /// This is a helper method to prevent the user from entering a negative number
        /// </summary>
        /// <param name="arraySize">arraySize comes from the caller method</param>
        /// <returns>a bool to keep the while loop runing or stop it</returns>
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

        /// <summary>
        /// This adds all the numbers in the array together and then divides that sume by the array length
        /// </summary>
        /// <param name="inputArray">array recieved from the users input in the caller</param>
        /// <returns>decimal average of the array</returns>
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

        /// <summary>
        /// caller method for challenge 3
        /// </summary>
        static void Challenge3Caller()
        {
            MakeDimond();
        }

        /// <summary>
        /// This makes a dimond on a board that is 9x9. The first outer `for` loop builds the top half.
        /// the second outer `for` loop builds the bottom half. It's hard coded but you could make 'rows' 
        /// a user defined variable so they can choose how big they want the dimond.
        /// </summary>
        public static void MakeDimond()
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

        /// <summary>
        /// This is the caller method for challenge 4.
        /// It enters in the example array from the assignment.
        /// </summary>
        static void Challenge4Caller()
        {

            int[] exampleArray = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            int testDuplicateMethod = MostDuplicates(exampleArray);
            Console.WriteLine("Example: Input: [1,1,2,2,3,3,3,1,1,5,5,6,7,8,2,1,1]");
            Console.WriteLine($"output: {testDuplicateMethod}");
        }

        /// <summary>
        /// This method returns the number that has the most duplicates. It starts with the first poition in the input array
        /// then checks each item again the array again. This is terrible its O(^n) but I have been working on this lab to long.
        /// When I have the patience I will think of a better solution.
        /// </summary>
        /// <param name="inputArray">an array of integers provided by the caller method</param>
        /// <returns>the integer with the most duplicates.</returns>
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

        /// <summary>
        /// This is the caller method for challenge 5.
        /// It enters in the example array from the assignment.
        /// </summary>
        static void Challenge5Caller()
        {
            int[] exampleArray = new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 };
            int testFindMaximumValue = FindMaximumValue(exampleArray);
            Console.WriteLine("Example: input [5, 25, 99, 123, 78, 96, 555, 108, 4]");
            Console.WriteLine($"return: {testFindMaximumValue}");
        }

        /// <summary>
        /// This starts with the first position in the array and then checks to see if there is anything larger.
        /// the moment the is something larger then that is the int that gets checked with the rest of the array.
        /// </summary>
        /// <param name="inputArray">an array of integers provided by the caller method</param>
        /// <returns>the highest value integer in the array</returns>
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

        /// <summary>
        /// This is the caller for challenge 6. Also provides the path of the words.txt file.
        /// This also takes in user input to send to the text file.
        /// </summary>
        static void Challenge6Caller()
        {
            string path = "../../../words.txt";

            Console.WriteLine("Please enter a word: ");
            string userString = Console.ReadLine();

            AppendWordTofile(path, userString);
        }

        /// <summary>
        /// This takes the word proved by the caller and adds it to the file.
        /// </summary>
        /// <param name="path">a path in the type string</param>
        /// <param name="inputWord">a word to be appened to the txt document</param>
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

        /// <summary>
        /// This is the caller for challenge 7. Also provides the path of the words.txt file.        
        /// </summary>
        static void Challenge7Caller()
        {
            string path = "../../../words.txt";

            string outputFromMethod = ReadAllTextFromFile(path);
            Console.WriteLine(outputFromMethod);
        }

        /// <summary>
        /// This take the path from the caller and uses that to get the data from the text file
        /// and returns it to the caller
        /// </summary>
        /// <param name="path">a path in the type string</param>
        /// <returns>returns a string made from the data of the text file</returns>
        static string ReadAllTextFromFile(string path)
        {
            string result = File.ReadAllText(path);

            return result;
        }

        /// <summary>
        /// The caller for challenge 8. Provides a path and a word to be removed.
        /// </summary>
        static void Challenge8Caller()
        {
            string path = "../../../words.txt";

            string remove = ChoseAWord(path);

            RemoveAWord(path, remove);
        }

        /// <summary>
        /// Helper function to get a word to be removed
        /// </summary>
        /// <param name="path">a string path</param>
        /// <returns>a single word from the text document</returns>
        static string ChoseAWord(string path)
        {
            string stringFromFile = ReadAllTextFromFile(path);

            string[] words = stringFromFile.Split(" ");

            return words[1];
        }

        /// <summary>
        /// This method reads all the text from the file. Turns the words into an array. Finds the index of the word
        /// to be removed then gets rid of that word.
        /// </summary>
        /// <param name="path">string path</param>
        /// <param name="removeThisWord">the word to be removed</param>
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

        /// <summary>
        /// The caller for challenge 9. Provides a space for user input to make word then calls the WordLengthGetter method
        /// </summary>
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

        /// <summary>
        /// This passes in a sentance. The string gets split into an array. The array goes through a loop and each item
        /// in the array gets its length added to itself. The array is joined back together and returned to the caller.
        /// </summary>
        /// <param name="sentance">a string</param>
        /// <returns>an array of the string with each word's letter count added to each index.</returns>
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
