using Videogame;

namespace MiniRpg2022.Console;

public class ShowDataMenu : MenuItem
{
    public ShowDataMenu() : base(2, "Show character data")
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