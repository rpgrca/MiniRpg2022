using Videogame;

namespace MiniRpg2022.Console;

public class ShowDataMenu : MenuItem
{
    public ShowDataMenu() : base("Show character data")
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
        DisplayDataFrom(configuration.GetCharacter(name));
        return false;
    }

    private static void DisplayDataFrom(Character character)
    {
        System.Console.WriteLine(Environment.NewLine +
            $"Name: {character.Name}" + Environment.NewLine +
            $"Nickname: {character.Nickname}" + Environment.NewLine +
            $"Occupation: {character.Occupation}" + Environment.NewLine +
            $"Birthday: {character.Birthday}");
    }
}

public class LoadPropertiesMenu : MenuItem
{
    public LoadPropertiesMenu() : base("Load properties")
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
            .Build();

        configuration.RegisterCharacter(character);
        return false;
    }
}