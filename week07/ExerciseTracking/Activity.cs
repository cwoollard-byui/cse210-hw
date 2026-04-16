public abstract class Activity
{
    private string _date;
    protected int _lengthMinutes;
    private string _activityName;

    public Activity(string date, int lengthMinutes, string activityName)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
        _activityName = activityName;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {_activityName} ({_lengthMinutes} min): Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
