namespace Videogame;

public class Speed
{
    public int Value { get; }

    public static Speed From(int value) => new(value);

    private Speed(int speed)
    {
        if (speed < 1 || speed > 10) throw new ArgumentException("Invalid speed", nameof(speed));
        Value = speed;
    }
}