public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthMinutes, double speed) : base(date, lengthMinutes, "Cycling")
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _lengthMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
