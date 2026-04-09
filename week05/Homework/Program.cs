using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Nigel Smith", "Photosynthesis");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Beatrice Jones", "Quadratic Equations", "12.4", "3-27");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Alistair Cameron", "Norse Mythology", "The Twilight of the Gods: Ragnarok in Modern Literature");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
