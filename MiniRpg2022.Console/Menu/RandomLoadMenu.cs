using MiniRpg2022.Logic.Characteristics;
using Videogame;

namespace MiniRpg2022.Console;

public class RandomLoadMenu : MenuItem
{
    public RandomLoadMenu() : base("Create character randomly")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var name = configuration.GetRandomName();
        var occupation = configuration.GetRandomOccupation();
        var birthday = configuration.GetRandomBirthday();
        var properties = configuration.GetProperties();

        var builder = new Character.Builder()
            .Called(name)
            .CreatingPropertiesWith(new PropertyFactory(properties.ToDictionary(p => p.Name)))
            .BornOn(new Birthday.Builder().BornOn(birthday).Build())
            .As(occupation);

        foreach (var property in properties)
        {
            builder.WithProperty(property.Name, configuration.GetRandomValueFor(property));
        }

        var character = builder.Build();
        configuration.RegisterCharacter(character);

        System.Console.WriteLine($"{character.Name} properties generated randomly.");
        return false;
    }
}