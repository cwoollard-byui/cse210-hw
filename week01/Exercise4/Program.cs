using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        int sum = 0;
        int maxNumber = 0;
        int smallestPositive = 0;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
                sum += number;
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
                if (number > 0)
                {
                    if (smallestPositive == 0)
                    {
                        smallestPositive = number;
                    }
                    else if (number < smallestPositive)
                    {
                        smallestPositive = number;
                    }
                }
            }
        } while (number != 0);
        double average = (double)sum / (double)numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (var item in numbers)
        {
            Console.WriteLine($"{item}");
        }
    }
}