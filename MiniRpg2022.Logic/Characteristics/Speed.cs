namespace Videogame;

public class LimitedValueBetween
{
    protected int Value { get; }

    protected LimitedValueBetween(int minimum, int maximum, int value)
    {
        if (value < minimum || value > maximum) throw new ArgumentException($"Invalid property value {value}");
        Value = value;
    }
}

public class Speed : LimitedValueBetween
{
    public static Speed From(int value) => new(value);

    private Speed(int speed) : base(1, 10, speed)
    {
    }

    public static implicit operator int(Speed speed) => speed.Value;
}

public class Dexterity : LimitedValueBetween
{
    public static Dexterity From(int value) => new(value);

    private Dexterity(int dexterity) : base(1, 5, dexterity)
    {
    }

    public static implicit operator int(Dexterity dexterity) => dexterity.Value;
}