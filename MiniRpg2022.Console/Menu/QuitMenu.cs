using Videogame;

namespace MiniRpg2022.Console;

public class QuitMenu : MenuItem
{
    public QuitMenu() : base("Quit")
    {
    }

    public override bool Execute(Configuration configuration)
    {
        var option = Choose("Are you sure?", new List<string> { "Y", "N" });
        return option == "Y";
    }
}