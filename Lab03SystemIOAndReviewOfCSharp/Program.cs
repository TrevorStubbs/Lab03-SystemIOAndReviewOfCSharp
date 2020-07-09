using System;

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
            //Challenge1Caller();
            //Challenge2Caller();
            Challenge3Caller();
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
    }
}
