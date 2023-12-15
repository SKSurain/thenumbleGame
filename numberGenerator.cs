public class NumberGenerator
{
    private Random _random;

    public NumberGenerator()
    {
        _random = new Random();
    }

    public int GenerateNumber(int max)
    {
        return _random.Next(1, max + 1);
    }
}
