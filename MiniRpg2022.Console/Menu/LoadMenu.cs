using Videogame;

namespace MiniRpg2022.Console;

public class LoadMenu : MenuItem
{
    public LoadMenu() : base(1, "Create character")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var occupation = Choose("Please choose an occupation", configuration.GetOccupationNames());
        var name = Prompt("Please name your character", v => string.IsNullOrEmpty(v));
        var nickname = Prompt("Add a nickname for your character", v => v is null);
        var birthday = Prompt("Please input your character birthday", v => DateOnly.TryParse(v, out _));

        return false;
    }
}