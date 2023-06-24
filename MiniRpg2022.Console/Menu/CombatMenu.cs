using Videogame;

namespace MiniRpg2022.Console;

public class CombatMenu : MenuItem
{
    public CombatMenu() : base("Combat")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var count = configuration.GetCharactersAlive();
        if (count == 0)
        {
            configuration.Messaging.Show("No loaded characters still.");
            return false;
        }

        var names = configuration.GetCharacterNames().ToList();
        if (count == 1)
        {
            configuration.Messaging.Show($"{names[0]} cannot battle himself.");
            return false;
        }

        var firstName = names[0];
        var secondName = names[1];
        if (count > 2)
        {
            firstName = configuration.Messaging.Choose("Choose the first fighter", names);
            names.Remove(firstName);
            secondName = configuration.Messaging.Choose("Choose the second fighter", names);
        }

        configuration.Messaging.Show($"{firstName} will fight {secondName}!");
        /*
        var battle = new Battle(configuration.GetCharacter(firstName), configuration.GetCharacter(secondName));
        for (var round = 0; round < 3; round++)
        {

        }*/
        return false;
    }
}