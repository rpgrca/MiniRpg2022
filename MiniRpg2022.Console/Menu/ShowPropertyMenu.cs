using Videogame;

namespace MiniRpg2022.Console;

public class ShowPropertyMenu : MenuItem
{
    public ShowPropertyMenu() : base("Show character properties")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var names = configuration.GetCharacterNames();
        if (! names.Any())
        {
            configuration.Messaging.Show("No loaded characters still.");
            return false;
        }

        var name = configuration.Messaging.Choose("Choose a character", names);
        DisplayPropertiesFrom(configuration, configuration.GetCharacter(name));
        return false;
    }

    private static void DisplayPropertiesFrom(Configuration configuration, Character character) =>
        configuration.Messaging.Show(Environment.NewLine +
            $"Name: {character.Name}" + Environment.NewLine +
            string.Join(Environment.NewLine, configuration.GetProperties().Select(p => $"{p.Name} ({p.Minimum}..{p.Maximum}): {character.GetValueFor(p.Name)}")));
}