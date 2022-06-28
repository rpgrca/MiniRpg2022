using MiniRpg2022.Logic.Characteristics;
using Videogame;

namespace MiniRpg2022.Console;

public class ManualLoadPropertiesMenu : MenuItem
{
    public ManualLoadPropertiesMenu() : base("Load properties manually")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var names = configuration.GetCharacterNames();
        if (! names.Any())
        {
            System.Console.WriteLine("No loaded characters still.");
            return false;
        }

        var name = Choose("Choose a character", names);
        var character = configuration.GetCharacter(name);
        var characterBuilder = new Character.Builder();

        foreach (var property in configuration.GetProperties())
        {
            var value = PromptRange($"Choose value for {property.Name}", property.Minimum, property.Maximum);
            characterBuilder.WithProperty(property.Name, value);
        }

        character = characterBuilder
            .Called(character.Name)
            .AlsoKnownAs(character.Nickname)
            .BornOn(character.Birthday)
            .As(character.Occupation)
            .CreatingPropertiesWith(new PropertyFactory(configuration.GetProperties().ToDictionary(p => p.Name)))
            .Build();

        configuration.RegisterCharacter(character);
        return false;
    }
}