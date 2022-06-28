namespace MiniRpg2022.Logic.Characteristics;

public class PropertyValue
{
    private readonly Property _property;

    public string Name => _property.Name;
    public int Value { get; }

    public PropertyValue(Property property, int value)
    {
        if (value < property.Minimum || value > property.Maximum) throw new ArgumentException($"Invalid property value {value}");

        _property = property;

        Value = value;
    }
}