using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public class Configuration
{
    private readonly Dictionary<string, IOccupation> _occupations;
    private readonly Dictionary<string, Character> _characters;
    private readonly List<Property> _properties;

    public Configuration()
    {
        _occupations = new Dictionary<string, IOccupation>();
        _characters = new Dictionary<string, Character>();
        _properties = new List<Property>();
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
    }

    public IEnumerable<string> GetOccupationNames() => _occupations.Select(p => p.Key);

    public IEnumerable<string> GetCharacterNames() => _characters.Select(p => p.Key);

    public IOccupation GetOccupation(string name) => _occupations[name];

    public void RegisterProperty(Property property) => _properties.Add(property);

    public IEnumerable<Property> GetProperties() => _properties;
}