using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Building a Tree House from Scratch", "DIY Dan", 1200);
        video1.AddComment(new Comment("Marcus", "I built one last summer using your plans, turned out great!"));
        video1.AddComment(new Comment("Sophie", "What kind of wood do you recommend for rainy climates?"));
        video1.AddComment(new Comment("James", "The time-lapse at the end was so satisfying."));
        videos.Add(video1);

        Video video2 = new Video("Why Deep Sea Fish Look So Weird", "Ocean Facts", 540);
        video2.AddComment(new Comment("Tamara", "The viper fish segment gave me nightmares."));
        video2.AddComment(new Comment("Liam", "I had no idea bioluminescence was that common down there."));
        video2.AddComment(new Comment("Amelia", "Please do one on giant squid next!"));
        video2.AddComment(new Comment("Oscar", "Watched this three times already, so fascinating."));
        videos.Add(video2);

        Video video3 = new Video("Beginner's Guide to Sourdough Bread", "The Flour Hour", 950);
        video3.AddComment(new Comment("Elena", "My starter finally doubled after following your method!"));
        video3.AddComment(new Comment("Ben", "Any tips for getting a crispier crust?"));
        video3.AddComment(new Comment("Wendy", "I've been baking for years and still learned something new."));
        videos.Add(video3);

        Video video4 = new Video("Astrophotography on a Budget", "Stargazer Steve", 780);
        video4.AddComment(new Comment("Samantha", "Captured the Milky Way with your settings, incredible results."));
        video4.AddComment(new Comment("Carlos", "Would a used camera work just as well for this?"));
        video4.AddComment(new Comment("Ingrid", "The stacking tutorial at 8:00 was a game changer."));
        video4.AddComment(new Comment("Paul", "Finally a photography channel that doesn't require expensive gear!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
