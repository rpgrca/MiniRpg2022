using Videogame;

namespace MiniRpg2022.Console;

public class ShowDataMenu : MenuItem
{
    public ShowDataMenu() : base(2, "Show character data")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var name = Choose(Text, configuration.GetCharacterNames());
        DisplayDataFrom(configuration.GetCharacterOrDefault(name));
        return false;
    }

    private static void DisplayDataFrom(Character? character)
    {
        if (character is null)
        {
            System.Console.WriteLine("Unknown character");
        }
        else
        {
            System.Console.WriteLine($"Name: {character.Name}" +
                                     $"Nickname: {character.Nickname}" +
                                     $"Occupation: {character.Occupation}" +
                                     $"Birthday: {character.Birthday}");
        }
    }
}