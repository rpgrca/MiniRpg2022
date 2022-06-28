namespace MiniRpg2022.Logic.Characteristics;

public class Property
{
    private readonly int _minimum;
    private readonly int _maximum;

    public string Name { get; }
    public int Value { get; }

    public Property(string name, int minimum, int maximum, int value)
    {
        if (value < minimum || value > maximum) throw new ArgumentException($"Invalid property value {value}");

        _minimum = minimum;
        _maximum = maximum;

        Name = name;
        Value = value;
    }
}