public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthMinutes, int laps) : base(date, lengthMinutes, "Swimming")
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _lengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthMinutes / GetDistance();
    }
}
