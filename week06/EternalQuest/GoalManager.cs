public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private List<Reward> _rewards;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _rewards = new List<Reward>();
    }

    public void Start()
    {
        string choice = "";

        while (choice != "9")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Create Reward");
            Console.WriteLine("  7. List Rewards");
            Console.WriteLine("  8. Claim Reward");
            Console.WriteLine("  9. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                CreateReward();
            }
            else if (choice == "7")
            {
                ListRewards();
            }
            else if (choice == "8")
            {
                ClaimReward();
            }

            if (choice != "9")
            {
                Console.WriteLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        _goals = new List<Goal>();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int amountCompleted = int.Parse(data[5]);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
        }
    }

    public void CreateReward()
    {
        Console.Write("What is the name of the reward? ");
        string name = Console.ReadLine();
        Console.Write("What is the points value of this reward? ");
        int cost = int.Parse(Console.ReadLine());
        _rewards.Add(new Reward(name, cost));
    }

    public void ListRewards()
    {
        Console.WriteLine("The rewards are:");
        for (int i = 0; i < _rewards.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_rewards[i].GetDetailsString()}");
        }
    }

    public void ClaimReward()
    {
        Console.WriteLine("The rewards are:");
        for (int i = 0; i < _rewards.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_rewards[i].GetName()} ({_rewards[i].GetCost()} points)");
        }
        Console.Write("Which reward would you like to claim? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _rewards.Count)
        {
            Reward reward = _rewards[index];
            if (reward.IsClaimed())
            {
                Console.WriteLine("You have already claimed this reward.");
            }
            else if (_score >= reward.GetCost())
            {
                _score -= reward.GetCost();
                reward.Claim();
                Console.WriteLine($"Congratulations! You have claimed the reward: {reward.GetName()}!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("You do not have enough points to claim this reward.");
            }
        }
    }
}
