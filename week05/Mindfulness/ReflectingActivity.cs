using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availablePrompts;
    private List<string> _availableQuestions;

    public ReflectingActivity()
        : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

        _availablePrompts = new List<string>(_prompts);
        _availableQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.Write("Now ponder on each of the following questions as they related to this experience.");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_prompts);
        }

        Random random = new Random();
        int index = random.Next(0, _availablePrompts.Count);
        string prompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index);
        return prompt;
    }

    public string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            _availableQuestions = new List<string>(_questions);
        }

        Random random = new Random();
        int index = random.Next(0, _availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}
