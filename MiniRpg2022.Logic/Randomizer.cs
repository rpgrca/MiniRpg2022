using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public class Randomizer
{
    private readonly DateOnly _today;
    private readonly List<string> _names;
    private readonly List<IOccupation> _occupations;
    private readonly List<Property> _properties;
    private readonly Random _randomGenerator;

    public Randomizer(List<string> names, DateOnly today, Dictionary<string, IOccupation> occupations, List<Property> properties)
    {
        _names = names;
        _today = today;
        _occupations = occupations.Values.ToList();
        _properties = properties;
        _randomGenerator = new Random();
    }

    public string GenerateName()
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

    public Birthday GenerateBirthday() =>
        new Birthday.Builder()
            .BeingToday(_today)
            .BornOn(_today.AddYears(_randomGenerator.Next(-300, -1)))
            .Build();

    public int GetRandomValueFor(Property property) =>
        _randomGenerator.Next(property.Minimum, property.Maximum + 1);

    public IOccupation GenerateOccupation() =>
        _occupations[_randomGenerator.Next(0, _occupations.Count)];
}