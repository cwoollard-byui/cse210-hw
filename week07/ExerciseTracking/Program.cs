class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("10 Apr 2026", 45, 4.0);
        activities.Add(running);

        Cycling cycling = new Cycling("11 Apr 2026", 30, 10.0);
        activities.Add(cycling);

        Swimming swimming = new Swimming("12 Apr 2026", 60, 30);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
