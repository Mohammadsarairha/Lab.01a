using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void StartSequence()
        {
            Console.WriteLine("Please Enter a number greater than zero");
            int prompt = Convert.ToInt32(Console.ReadLine());
            while (prompt <= 0)
            {
                Console.WriteLine("Please Enter a number greater than zero");
                prompt = Convert.ToInt32(Console.ReadLine());
            }
            int[] userArray = new int[prompt];
            int[] populateArr = Populate(userArray);
            int sum = GetSum(populateArr);
            int product = GetProduct(populateArr, sum);
            decimal quotient = GetQuotient(product);
            Console.WriteLine($"Your array is size {userArray.Length}");
            Console.WriteLine($"The numbers in the array are {string.Join(",", populateArr)}");
            Console.WriteLine($"The sum of the array is {sum}");
            Console.WriteLine($"Quotient is {quotient}");
        }
        static int[] Populate(int[] arr)
        {
            int prompt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter a number {i + 1} / {arr.Length}");
                prompt = Int32.Parse(Console.ReadLine());
                arr[i] = prompt;
            }
            return arr;
        }
        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int[] array, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {array.Length}");
            int random = Int32.Parse(Console.ReadLine());
            int product = sum * array[random - 1];

            return product;
        }
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide ypur product {product} by");
                decimal prompt = Decimal.Parse(Console.ReadLine());
                decimal quotient = decimal.Divide(product, prompt);
                return quotient;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wrong happened : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("program is completed");
            }
        }
    }
}
