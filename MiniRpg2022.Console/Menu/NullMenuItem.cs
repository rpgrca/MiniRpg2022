using Videogame;

namespace MiniRpg2022.Console;

public class NullMenuItem : MenuItem
{
    public NullMenuItem() : base(string.Empty)
    {
    }

    public override bool Execute(Configuration configuration) => false;
}

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
            System.Console.WriteLine("No loaded characters still.");
            return false;
        }

        var names = configuration.GetCharacterNames().ToList();
        if (count == 1)
        {
            System.Console.WriteLine($"{names[0]} cannot battle himself.");
            return false;
        }

        var firstName = names[0];
        var secondName = names[1];
        if (count > 2)
        {
            firstName = Choose("Choose the first fighter", names);
            names.Remove(firstName);
            secondName = Choose("Choose the second fighter", names);
        }

        System.Console.WriteLine($"{firstName} will fight {secondName}!");
        /*
        var battle = new Battle(configuration.GetCharacter(firstName), configuration.GetCharacter(secondName));
        for (var round = 0; round < 3; round++)
        {

        }*/
        return false;
    }
}