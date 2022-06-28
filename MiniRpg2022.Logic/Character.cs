using System.Linq;
using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public partial class Character
{
    private readonly Dictionary<string, PropertyValue> _properties;

    public string Name { get; }
    public string Nickname { get; }
    public Birthday Birthday { get; }
    public IOccupation Occupation { get; }
    public int Health { get; }

    private Character(string name, string nickname, Birthday birthday, IOccupation occupation, Dictionary<string, PropertyValue> properties)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));
        if (nickname is null) throw new ArgumentException("Invalid nickname", nameof(nickname));
        if (birthday is null) throw new ArgumentException("Invalid birthday", nameof(birthday));
        if (occupation is null) throw new ArgumentException("Invalid occupation", nameof(occupation));
        if (properties is null) throw new ArgumentException("Invalid properties", nameof(properties));

        Name = name;
        Nickname = nickname;
        Birthday = birthday;
        Occupation = occupation;
        Health = 100;

        _properties = properties;
    }

    public int GetValueFor(string property) => _properties.ContainsKey(property)
        ? _properties[property].Value
        : -1;
}