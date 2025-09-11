using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string letter = "";
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        if (gradePercentage % 10 >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (gradePercentage % 10 < 3 && letter != "F")
        {
            sign = "-";
        }


        bool passedClass = false;
        if (gradePercentage >= 70)
        {
            passedClass = true;
        }

        Console.WriteLine();
        Console.WriteLine($"Your grade is {letter}{sign}");
        if (passedClass == true)
        {
            Console.WriteLine("You passed the class, congratulations!");
        }
        else
        {
            Console.WriteLine("You failed the class, good luck for next time!");
        }
    }
}