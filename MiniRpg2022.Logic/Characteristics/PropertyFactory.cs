namespace MiniRpg2022.Logic.Characteristics;

public class PropertyFactory : IPropertyFactory
{
    public class Builder
    {
        private Dictionary<string, Property> _properties;

        public Builder() => _properties = new Dictionary<string, Property>();

        public Builder With(Property property)
        {
            _properties.Add(property.Name, property);
            return this;
        }

        public IPropertyFactory Build() => new PropertyFactory(_properties);
    }

    public class Director
    {
        public static Builder AddDefaultProperties(Builder builder) => builder
            .With(new("speed", 1, 10))
            .With(new("dexterity", 1, 5))
            .With(new("strength", 1, 10))
            .With(new("level", 1, 10))
            .With(new("armour", 1, 10));
    }

    private readonly Dictionary<string, Property> _properties;

    public PropertyFactory(Dictionary<string, Property> properties) =>
        _properties = properties;

    public PropertyValue CreateFor(string name, int value) => new(_properties[name], value);
}