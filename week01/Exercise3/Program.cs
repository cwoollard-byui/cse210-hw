using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {

            // Console.Write("What is the magic number? ");
            // int number = int.Parse(Console.ReadLine());

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 3);

            int guess;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
            } while (guess != number);
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} guesses!");
            Console.WriteLine();
            Console.WriteLine("Do you want to play again?");
        } while (Console.ReadLine() == "yes");
    }
}