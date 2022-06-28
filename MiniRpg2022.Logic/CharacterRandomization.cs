using MiniRpg2022.Logic.Characteristics;

namespace Videogame;

public class CharacterRandomization
{
    private readonly PropertyFactory _propertiesFactory;
    private readonly Randomizer _randomizer;
    private readonly IEnumerable<Property> _properties;

    private IOccupation _randomOccupation;
    private string _randomName;
    private Birthday _randomBirthday;

    public CharacterRandomization(Configuration configuration)
    {
        _randomizer = configuration.CreateRandomizer();
        _properties = configuration.GetProperties();
        _propertiesFactory = new PropertyFactory(_properties.ToDictionary(p => p.Name));

        ChooseRandomName();
        ChooseRandomOccupation();
        ChooseRandomBirthday();
    }

    public Character Create()
    {
        var builder = new Character.Builder()
            .Called(_randomName)
            .CreatingPropertiesWith(_propertiesFactory)
            .BornOn(new Birthday.Builder().BornOn(_randomBirthday).Build())
            .As(_randomOccupation);

        foreach (var property in _properties)
        {
            builder.WithProperty(property.Name,  _randomizer.GetRandomValueFor(property));
        }

        return builder.Build();
    }

    private void ChooseRandomName() => _randomName = _randomizer.GenerateName();

    private void ChooseRandomOccupation() =>
        _randomOccupation = _randomizer.GenerateOccupation();

    private void ChooseRandomBirthday() =>
        _randomBirthday = _randomizer.GenerateBirthday();
}