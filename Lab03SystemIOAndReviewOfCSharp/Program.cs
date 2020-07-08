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
            Challenge1Caller();
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
    }
}
