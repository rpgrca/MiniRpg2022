using Videogame;

namespace MiniRpg2022.Console;

public class NullMenuItem : MenuItem
{
    public NullMenuItem() : base(0, string.Empty)
    {
    }

    public override bool Execute(Configuration configuration) => false;
}