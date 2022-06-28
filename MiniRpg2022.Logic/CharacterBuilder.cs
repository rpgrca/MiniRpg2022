using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public partial class Character
{
    public class Builder
    {
        private string _name;
        private string _nickname;
        private Birthday _birthday;
        private IOccupation _occupation;
        private readonly Dictionary<string, int> _properties;
        private IPropertyFactory _propertyFactory;

        public Builder()
        {
            _name = string.Empty;
            _nickname = string.Empty;
            _properties = new Dictionary<string, int>();
            _propertyFactory = new PropertyFactory();
        }

        public Builder Called(string name)
        {
            _name = name;
            return this;
        }

        public Builder AlsoKnownAs(string nickname)
        {
            _nickname = nickname;
            return this;
        }

        public Builder BornOn(Birthday birthday)
        {
            _birthday = birthday;
            return this;
        }

        public Builder As(IOccupation occupation)
        {
            _occupation = occupation;
            return this;
        }

        public Builder WithProperty(string name, int value)
        {
            if (_properties.ContainsKey(name))
            {
                _properties[name] = value;
            }
            else
            {
                _properties.Add(name, value);
            }

            return this;
        }

        public Builder CreatingPropertiesWith(IPropertyFactory propertyFactory)
        {
            _propertyFactory = propertyFactory;
            return this;
        }

        public Character Build()
        {
            var properties = _properties.Select(p => _propertyFactory.CreateFor(p.Key, p.Value)).ToDictionary(p => p.Name);
            return new(_name, _nickname, _birthday, _occupation, properties);
        }
    }
}