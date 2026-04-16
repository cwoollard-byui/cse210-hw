public class Reward
{
    private string _name;
    private int _cost;
    private bool _isClaimed;

    public Reward(string name, int cost)
    {
        _name = name;
        _cost = cost;
        _isClaimed = false;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetCost()
    {
        return _cost;
    }

    public bool IsClaimed()
    {
        return _isClaimed;
    }

    public void Claim()
    {
        _isClaimed = true;
    }

    public string GetDetailsString()
    {
        string checkbox = _isClaimed ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_cost} points)";
    }
}
