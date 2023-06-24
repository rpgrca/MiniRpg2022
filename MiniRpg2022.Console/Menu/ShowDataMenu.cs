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
            configuration.Messaging.Show("No loaded characters still.");
            return false;
        }

        var name = configuration.Messaging.Choose("Choose a character", names);
        DisplayDataFrom(configuration.Messaging, configuration.GetCharacter(name));
        return false;
    }

    private static void DisplayDataFrom(IMessaging messaging, Character character)
    {
        messaging.Show(Environment.NewLine +
            $"Name: {character.Name}" + Environment.NewLine +
            $"Nickname: {character.Nickname}" + Environment.NewLine +
            $"Occupation: {character.Occupation}" + Environment.NewLine +
            $"Birthday: {character.Birthday}");
    }
}

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