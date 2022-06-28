namespace MiniRpg2022.Logic.Characteristics;

public class LimitedValueBetween
{
    protected int Value { get; }

    protected LimitedValueBetween(int minimum, int maximum, int value)
    {
        if (value < minimum || value > maximum) throw new ArgumentException($"Invalid property value {value}");
        Value = value;
    }
}
