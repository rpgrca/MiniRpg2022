namespace MiniRpg2022.Logic.Characteristics;

public class PropertyFactory : IPropertyFactory
{
    private readonly Dictionary<string, (int Minimum, int Maximum)> _properties;

    public PropertyFactory()
    {
        _properties = new Dictionary<string, (int Minimum, int Maximum)>
        {
            { "speed", (1, 10) },
            { "dexterity", (1, 5) },
            { "strength", (1, 10) },
            { "level", (1, 10) },
            { "armour", (1, 10) }
        };
    }

    public Property CreateFor(string name, int value) => new(name, _properties[name].Minimum, _properties[name].Maximum, value);
}