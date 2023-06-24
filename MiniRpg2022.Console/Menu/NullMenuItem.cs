using Videogame;

namespace MiniRpg2022.Console;

public class NullMenuItem : MenuItem
{
    public NullMenuItem() : base(string.Empty)
    {
    }

    public override bool Execute(Configuration configuration) => false;
}