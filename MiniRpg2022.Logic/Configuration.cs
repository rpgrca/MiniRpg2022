using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public class Configuration
{
    private readonly Dictionary<string, IOccupation> _occupations;
    private readonly Dictionary<string, Character> _characters;
    private readonly List<string> _names;
    private readonly List<Property> _properties;
    private readonly DateOnly _today;
    private readonly Random _randomGenerator;

    public Configuration(int year, int month, int day)
    {
        _occupations = new Dictionary<string, IOccupation>();
        _characters = new Dictionary<string, Character>();
        _properties = new List<Property>();
        _names = new List<string>();
        _today = new DateOnly(year, month, day);
        _randomGenerator = new Random();
    }

    public void RegisterOccupation(IOccupation occupation) =>
        _occupations.Add(occupation.ToString(), occupation);

    public Character? GetCharacterOrDefault(string name) =>
        !_characters.ContainsKey(name) ? null : _characters[name];

    public Character GetCharacter(string name) => _characters[name];

    public void RegisterCharacter(Character character)
    {
        if (_characters.ContainsKey(character.Name))
        {
            _characters[character.Name] = character;
        }
        else
        {
            _characters.Add(character.Name, character);
        }

        if (_names.Contains(character.Name))
        {
            _names.Remove(character.Name);
        }
    }

    public void RegisterName(string name)
    {
        if (! _names.Contains(name))
        {
            _names.Add(name);
        }
    }

    public IEnumerable<string> GetOccupationNames() => _occupations.Select(p => p.Key);

    public IEnumerable<string> GetCharacterNames() => _characters.Select(p => p.Key);

    public IOccupation GetOccupation(string name) => _occupations[name];

    public void RegisterProperty(Property property) => _properties.Add(property);

    public IOccupation GetRandomOccupation() =>
        _occupations.Values.ToArray()[_randomGenerator.Next(0, _occupations.Count)];

    public Birthday GetRandomBirthday() =>
        new Birthday.Builder()
            .BeingToday(_today)
            .BornOn(_today.AddYears(_randomGenerator.Next(-300, -1)))
            .Build();

    public int GetRandomValueFor(Property property) =>
        _randomGenerator.Next(property.Minimum, property.Maximum + 1);

    public string GetRandomName()
    {
        if (_names.Count == 0)
        {
            return $"Name{_randomGenerator.Next()}";
        }

        var randomValue = _randomGenerator.Next(0, _names.Count);

        var name = _names[randomValue];
        _names.Remove(name);
        return name;
    }

    public IEnumerable<Property> GetProperties() => _properties;
}