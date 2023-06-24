using Videogame;
using MiniRpg2022.Console;

namespace MiniRpg2022.Runtime;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new Configuration(2022, 6, 28, new Messaging(new Console.Console()));

        configuration.RegisterOccupation(new Mage());
        configuration.RegisterOccupation(new Warrior());
        configuration.RegisterOccupation(new Archer());
        configuration.RegisterOccupation(new Thief());

        configuration.RegisterProperty(new("speed", 1, 10));
        configuration.RegisterProperty(new("dexterity", 1, 5));
        configuration.RegisterProperty(new("strength", 1, 10));
        configuration.RegisterProperty(new("level", 1, 10));
        configuration.RegisterProperty(new("armour", 1, 10));

        configuration.RegisterName("Raistlin Majere");
        configuration.RegisterName("Tanis Half-Elven");
        configuration.RegisterName("Sturm Brightblade");
        configuration.RegisterName("Goldmoon");


        var menu = new Menu(configuration);
        menu.Execute();
    }
}