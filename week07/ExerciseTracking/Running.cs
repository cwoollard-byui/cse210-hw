public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthMinutes, double distance) : base(date, lengthMinutes, "Running")
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _lengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthMinutes / _distance;
    }
}
